using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Yarp.EfCore.Configuration.Base;
using Yarp.EfCore.Configuration.Configurations;
using Yarp.EfCore.Configuration.Extensions;
using Yarp.EfCore.Configuration.PostgreSql;
using Yarp.EfCore.Configuration.PostgreSql.Configs;
using Yarp.EfCore.Configuration.PostgreSql.Services;
using Yarp.ReverseProxy.Configuration;

// ReSharper disable once CheckNamespace
namespace Yarp.EfCore.Configuration;

public static class ReverseProxyBuilderExtensions
{
    public static IReverseProxyBuilder LoadFromPostgreSql(this IReverseProxyBuilder builder, Action<PostgreSqlConfig> options)
    {
        var config = new PostgreSqlConfig();
        options(config);
        builder.Services.AddKeyedSingleton<BaseProviderConfig>(nameof(PostgreSql),config);
        builder.Services.AddDbContext<YarpDbContext, PostgreYarpDbContext>(o =>
        {
            o.UseNpgsql(config.ConnectionString, optionsBuilder =>
            {
                optionsBuilder.EnableRetryOnFailure(config.RetryCount, config.RetryInterval, null);
                optionsBuilder.MigrationsAssembly(typeof(PostgreYarpDbContext).Assembly.FullName);
            });
        }, ServiceLifetime.Singleton, ServiceLifetime.Singleton);
        builder.Services.AddSingleton<IProxyConfigProvider,EfCoreConfigurationProvider<PostgreYarpDbContext>>();
        builder.Services.AddHostedService<UpdateCheckService>();
        return builder;
    }
}