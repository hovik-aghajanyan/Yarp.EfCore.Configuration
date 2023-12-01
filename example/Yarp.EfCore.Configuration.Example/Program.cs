using Yarp.EfCore.Configuration;
using Yarp.EfCore.Configuration.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy().LoadFromPostgreSql(o =>
{
    o.ConnectionString = "Host=localhost;Port=5432;Database=yarp;Username=superfleet;Password=superfleet";
    o.CheckUpdateInterval = TimeSpan.FromMinutes(2);
});



var app = builder.Build();
app.MigrateYarpDb();
app.MapGet("/", () => "Hello World!");
app.MapReverseProxy();

app.Run();
