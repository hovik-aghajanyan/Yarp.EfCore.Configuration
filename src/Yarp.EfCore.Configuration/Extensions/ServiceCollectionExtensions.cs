using Microsoft.Extensions.DependencyInjection;
using Yarp.EfCore.Configuration.Configurations;
using Yarp.EfCore.Configuration.Services;
using Yarp.ReverseProxy.Configuration;

namespace Yarp.EfCore.Configuration.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUpdateService(this IServiceCollection services)
    {
        services.AddSingleton<EfCoreConfigurationProvider>();
        services.AddSingleton<IProxyConfigProvider,EfCoreConfigurationProvider>();
        services.AddSingleton<UpdateCheckService>();
        services.AddHostedService<UpdateCheckService>();
        return services;
    }
}