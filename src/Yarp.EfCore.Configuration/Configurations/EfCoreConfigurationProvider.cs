using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yarp.ReverseProxy.Configuration;

namespace Yarp.EfCore.Configuration.Configurations;

public class EfCoreConfigurationProvider:IProxyConfigProvider
{
    private readonly ILogger<EfCoreConfigurationProvider> _logger;
    private readonly IMapper _mapper;

    private readonly YarpDbContext _dbContext;
    private volatile EfCoreConfig _config = new(Array.Empty<RouteConfig>(), Array.Empty<ClusterConfig>(), Guid.NewGuid().ToString("N"));

    public EfCoreConfigurationProvider(
        ILogger<EfCoreConfigurationProvider> logger,
        IMapper mapper,
        YarpDbContext dbContext)
    {
        _logger = logger;
        _mapper = mapper;
        _dbContext = dbContext;
        Update();
    }
    /// <summary>
    /// Implementation of the IProxyConfigProvider.GetConfig method to supply the current snapshot of configuration
    /// </summary>
    /// <returns>An immutable snapshot of the current configuration state</returns>
    public IProxyConfig GetConfig() => _config;

    /// <summary>
    /// Swaps the config state with a new snapshot of the configuration, then signals that the old one is outdated.
    /// </summary>
    public async void Update()
    {
        var routes = await _dbContext.RouteConfigs.Where(r => r.IsEnabled).ProjectTo<RouteConfig>(_mapper.ConfigurationProvider).ToListAsync();
        var clusters = await _dbContext.ClusterConfigs.ProjectTo<ClusterConfig>(_mapper.ConfigurationProvider).ToListAsync();
        var newConfig = new EfCoreConfig(routes, clusters, Guid.NewGuid().ToString("N"));
        UpdateInternal(newConfig);
    }

    private void UpdateInternal(EfCoreConfig newConfig)
    {
        var oldConfig = Interlocked.Exchange(ref _config, newConfig);
        oldConfig.SignalChange();
    }
}