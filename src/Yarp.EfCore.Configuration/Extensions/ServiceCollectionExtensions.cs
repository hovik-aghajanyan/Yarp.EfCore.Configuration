using Microsoft.Extensions.DependencyInjection;
using Yarp.EfCore.Configuration.Configurations;
using Yarp.EfCore.Configuration.Services;

namespace Yarp.EfCore.Configuration.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUpdateService(this IServiceCollection services)
    {
        services.AddAutoMapper(o => {  },new[] {typeof(ServiceCollectionExtensions)},ServiceLifetime.Singleton );
        services.AddSingleton<EfCoreConfigurationProvider>();
        services.AddSingleton<UpdateCheckService>();
        services.AddHostedService<UpdateCheckService>();
        return services;
    }
}