using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Yarp.EfCore.Configuration.Base;
using Yarp.EfCore.Configuration.Configurations;
using Yarp.EfCore.Configuration.Extensions;
using Yarp.EfCore.Configuration.MsSql;
using Yarp.EfCore.Configuration.MsSql.Configs;
using Yarp.ReverseProxy.Configuration;

// ReSharper disable once CheckNamespace
namespace Yarp.EfCore.Configuration;

public static class ReverseProxyBuilderExtensions
{
    public static IReverseProxyBuilder LoadFromMsSql(this IReverseProxyBuilder builder, Action<MsSqlConfig> options)
    {
        var config = new MsSqlConfig();
        options(config);
        builder.Services.AddSingleton<BaseProviderConfig>(config);
        builder.Services.AddDbContext<YarpDbContext, MsSqlYarpDbContext>(o =>
        {
            o.UseSqlServer(config.ConnectionString, optionsBuilder =>
            {
                optionsBuilder.EnableRetryOnFailure(config.RetryCount, config.RetryInterval, null);
                optionsBuilder.MigrationsAssembly(typeof(MsSqlYarpDbContext).Assembly.FullName);
            });
        }, ServiceLifetime.Singleton, ServiceLifetime.Singleton);
        builder.Services.AddSingleton<IProxyConfigProvider,EfCoreConfigurationProvider>();
        if(config.CheckUpdateInterval is not null)
        {
            builder.Services.AddUpdateService();
        }
        return builder;
    }
}