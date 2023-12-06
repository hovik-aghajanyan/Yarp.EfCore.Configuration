using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yarp.EfCore.Configuration.Entities;
using Yarp.ReverseProxy.Configuration;

namespace Yarp.EfCore.Configuration.Configurations;

public class EfCoreConfigurationProvider<TDbContext>(ILogger<TDbContext> logger,
        TDbContext dbContext)
    : IProxyConfigProvider where TDbContext : YarpDbContext
{

    private volatile EfCoreConfig _config = new(Array.Empty<RouteConfig>(), Array.Empty<ClusterConfig>(), Guid.NewGuid().ToString("N"));

    /// <summary>
    /// Implementation of the IProxyConfigProvider.GetConfig method to supply the current snapshot of configuration
    /// </summary>
    /// <returns>An immutable snapshot of the current configuration state</returns>
    public IProxyConfig GetConfig() => _config;

    /// <summary>
    /// Swaps the config state with a new snapshot of the configuration, then signals that the old one is outdated.
    /// </summary>
    public async Task Update()
    {
        var routes = await dbContext.RouteConfigs.Where(r => r.IsEnabled).ToListAsync();
        var clusters = await dbContext.ClusterConfigs.ToListAsync();
        var newConfig = new EfCoreConfig(routes.Select(r => r.ToConfig()).ToList(), clusters.Select(r => r.ToConfig()).ToList(), Guid.NewGuid().ToString("N"));
        UpdateInternal(newConfig);
    }

    private void UpdateInternal(EfCoreConfig newConfig)
    {
        var oldConfig = Interlocked.Exchange(ref _config, newConfig);
        oldConfig.SignalChange();
    }
}