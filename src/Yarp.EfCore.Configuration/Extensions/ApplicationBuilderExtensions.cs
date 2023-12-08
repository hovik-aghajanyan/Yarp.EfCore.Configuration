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
            var routeConfig = provider.GetConfig().Routes;
            var clusterConfig = provider.GetConfig().Clusters;
            if(routeConfig.Any())
            {
                routes.AddRange(routeConfig);
            }
            if(clusterConfig.Any())
            {
                clusters.AddRange(clusterConfig);
            }
        }
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TContext>();
        if(routes.Any())
        {
            context.AddRange(routes.Select(r => r.ToEntity()));
        }
        if(clusters.Any())
        {
            context.AddRange(clusters.Select(c => c.ToEntity()));
        }
        if(routes.Any() || clusters.Any())
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        return app;
    }
}