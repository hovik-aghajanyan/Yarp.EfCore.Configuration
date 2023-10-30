using Yarp.EfCore.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy().LoadFromPostgreSql();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapReverseProxy();

app.Run();