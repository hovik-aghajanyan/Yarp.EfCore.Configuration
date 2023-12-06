using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
}