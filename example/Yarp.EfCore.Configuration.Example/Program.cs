using Microsoft.AspNetCore.Mvc;
using Yarp.EfCore.Configuration;
using Yarp.EfCore.Configuration.Extensions;
using Yarp.ReverseProxy.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromMsSql(config =>
    {
        config.ConnectionString = "Server=localhost;Database=yarp;User Id=sa;Password=Q#w2e3r4;TrustServerCertificate=true";
    })
    .LoadFromPostgreSql(o =>
    {
        o.ConnectionString = "Host=localhost;Port=5432;Database=yarp;Username=superfleet;Password=superfleet";
        o.CheckUpdateInterval = TimeSpan.FromMinutes(1);
    });



var app = builder.Build();
app.MigrateYarpDb();
app.MapGet("/", () => "Hello World!");
app.MapPost("/route", ([FromBody] RouteConfig config, [FromServices] YarpDbContext dbContext) =>
{
    dbContext.RouteConfigs.Add(config.ToEntity());
    return dbContext.SaveChangesAsync();
});
app.MapPost("/cluster", ([FromBody] ClusterConfig config, [FromServices] YarpDbContext dbContext) =>
{
    dbContext.ClusterConfigs.Add(config.ToEntity());
    return dbContext.SaveChangesAsync();
});
app.MapReverseProxy();

app.Run();
