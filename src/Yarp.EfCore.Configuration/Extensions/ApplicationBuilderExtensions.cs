using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Yarp.ReverseProxy.Configuration;

namespace Yarp.EfCore.Configuration.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder MigrateYarpDb(this IApplicationBuilder app)
    {
        var context = app.ApplicationServices.GetServices<YarpDbContext>();
        foreach (var dbContext in context)
        {
            dbContext.Database.Migrate();
        }
        return app;
    }
    
    public static IApplicationBuilder MigrateYarpDb<T>(this IApplicationBuilder app) where T : YarpDbContext
    {
        var context = app.ApplicationServices.GetService<T>();
        context?.Database.Migrate();
        return app;
    } 
    
    public static IApplicationBuilder MigrateConfigsToDb<TContext>(this IApplicationBuilder app) where TContext: YarpDbContext
    {
        var providers = app.ApplicationServices.GetServices<IProxyConfigProvider>();
        List<RouteConfig> routes = new();
        List<ClusterConfig> clusters = new();
        foreach (var provider in providers)
        {
            routes.AddRange(provider.GetConfig().Routes);
            clusters.AddRange(provider.GetConfig().Clusters);
        }
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TContext>();
        context.AddRange(routes);
        context.AddRange(clusters);
        context.SaveChanges();
        return app;
    }
}