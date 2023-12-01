using Microsoft.Extensions.Hosting;
using Yarp.EfCore.Configuration.Base;
using Yarp.EfCore.Configuration.Configurations;

namespace Yarp.EfCore.Configuration.Services;

public class UpdateCheckService(EfCoreConfigurationProvider configurationProvider, BaseProviderConfig config)
    : BackgroundService
{
    private readonly TimeSpan? _checkInterval = config.CheckUpdateInterval;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested && _checkInterval is not null)
        {
            configurationProvider.Update();
            await Task.Delay(_checkInterval.Value, stoppingToken);
        }
    }
}