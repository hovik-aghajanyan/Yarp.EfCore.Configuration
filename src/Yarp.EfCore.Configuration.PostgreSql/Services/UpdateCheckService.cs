using System.Collections;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Yarp.EfCore.Configuration.Base;
using Yarp.EfCore.Configuration.Configurations;
using Yarp.ReverseProxy.Configuration;

namespace Yarp.EfCore.Configuration.PostgreSql.Services;

public class UpdateCheckService(IEnumerable<IProxyConfigProvider> configurationProviders, [FromKeyedServices(nameof(PostgreSql))] BaseProviderConfig config)
    : BackgroundService
{
    private readonly TimeSpan? _checkInterval = config.CheckUpdateInterval;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Update();
        while (!stoppingToken.IsCancellationRequested && _checkInterval is not null)
        {
            await Task.Delay(_checkInterval.Value, stoppingToken);
            await Update();
        }
    }
    
    private async Task Update()
    {
        try
        {
            foreach (var configurationProvider in configurationProviders)
            {
                if (configurationProvider is EfCoreConfigurationProvider<PostgreYarpDbContext>
                    efCoreConfigurationProvider)
                {
                    await efCoreConfigurationProvider.Update();
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}