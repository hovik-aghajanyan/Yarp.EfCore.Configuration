using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Yarp.EfCore.Configuration.Base;
using Yarp.EfCore.Configuration.Configurations;
using Yarp.EfCore.Configuration.Extensions;
using Yarp.EfCore.Configuration.MsSql;
using Yarp.EfCore.Configuration.MsSql.Configs;
using Yarp.EfCore.Configuration.MsSql.Services;
using Yarp.ReverseProxy.Configuration;

// ReSharper disable once CheckNamespace
namespace Yarp.EfCore.Configuration;

public static class ReverseProxyBuilderExtensions
{
    public static IReverseProxyBuilder LoadFromMsSql(this IReverseProxyBuilder builder, Action<MsSqlConfig> options)
    {
        var config = new MsSqlConfig();
        options(config);
        builder.Services.AddKeyedSingleton<BaseProviderConfig>(nameof(MsSql),config);
        builder.Services.AddDbContext<MsSqlYarpDbContext>(o =>
        {
            o.UseSqlServer(config.ConnectionString, optionsBuilder =>
            {
                optionsBuilder.EnableRetryOnFailure(config.RetryCount, config.RetryInterval, null);
                optionsBuilder.MigrationsAssembly(typeof(MsSqlYarpDbContext).Assembly.FullName);
            });
        }, ServiceLifetime.Singleton, ServiceLifetime.Singleton);
        builder.Services.AddSingleton<IProxyConfigProvider,EfCoreConfigurationProvider<MsSqlYarpDbContext>>();
        builder.Services.AddHostedService<UpdateCheckService>();
        return builder;
    }
    
    public static IApplicationBuilder MigrateConfigToDb(this IApplicationBuilder app)
    {
        app.MigrateYarpDb<MsSqlYarpDbContext>();
        app.MigrateConfigsToDb<MsSqlYarpDbContext>();
        return app;
    }
}