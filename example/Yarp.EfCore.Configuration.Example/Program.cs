using Yarp.EfCore.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy().LoadFromPostgreSql(o =>
{
    
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapReverseProxy();

app.Run();