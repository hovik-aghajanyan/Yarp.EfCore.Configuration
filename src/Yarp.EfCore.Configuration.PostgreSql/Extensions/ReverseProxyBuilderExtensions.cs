using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Yarp.EfCore.Configuration.Base;
using Yarp.EfCore.Configuration.Extensions;
using Yarp.EfCore.Configuration.PostgreSql;
using Yarp.EfCore.Configuration.PostgreSql.Configs;

// ReSharper disable once CheckNamespace
namespace Yarp.EfCore.Configuration;

public static class ReverseProxyBuilderExtensions
{
    public static IReverseProxyBuilder LoadFromPostgreSql(this IReverseProxyBuilder builder, Action<PostgreSqlConfig> options)
    {
        var config = new PostgreSqlConfig();
        options(config);
        builder.Services.AddSingleton<BaseProviderConfig, PostgreSqlConfig>();
        builder.Services.AddDbContext<YarpDbContext, PostgreYarpDbContext>(o =>
        {
            o.UseNpgsql(config.ConnectionString, optionsBuilder =>
            {
                optionsBuilder.EnableRetryOnFailure(config.RetryCount, config.RetryInterval, null);
                optionsBuilder.MigrationsAssembly(typeof(PostgreYarpDbContext).Assembly.FullName);
            });
        }, ServiceLifetime.Singleton, ServiceLifetime.Singleton);
        builder.Services.AddUpdateService();
        return builder;
    }
}