# Yarp.EfCore.Configuration

## Overview

Use one of the providers to Configure Yarp Proxy in centralized DB

### PostgreSQL
```bash
dotnet add package EfCore.Yarp.Configuration.PostgreSql
```


### MSSQL
```bash
dotnet add package EfCore.Yarp.Configuration.MsSql
```

### Example of usage

#### MsSql
```csharp
builder.Services.AddReverseProxy()
    .LoadFromMsSql(config =>
    {
        config.ConnectionString = "Server=localhost;Database=yarp_new;User Id=sa;Password=Q#w2e3r4;TrustServerCertificate=true";
        config.CheckUpdateInterval = TimeSpan.FromMinutes(1);
        config.RetryCount = 3;
        config.RetryInterval = TimeSpan.FromSeconds(10);
        config.ProxyName = "MyProxy";
    });
```

#### PostgreSql
```csharp
builder.Services.AddReverseProxy()
    .LoadFromPostgreSql(o =>
    {
        o.ConnectionString = "Host=localhost;Port=5432;Database=yarp_new;Username=superfleet;Password=superfleet";
        config.CheckUpdateInterval = TimeSpan.FromMinutes(1);
        config.RetryCount = 3;
        config.RetryInterval = TimeSpan.FromSeconds(10);
        config.ProxyName = "MyProxy";
    });
```
Each provider has the same configuration options:

- `ConnectionString` - connection string to DB (Required)
- `CheckUpdateInterval` - interval for checking updates in DB (Optional, if value is not specified configuration will not be updated)
- `RetryCount` - count of retries to connect to DB (Optional, default value is 3)
- `RetryInterval` - interval between retries to connect to DB (Optional, default value is 10 seconds)
- `ProxyName` - name of proxy (Optional, if proxy name is not specified, proxy will load all specified `RouteConfigs` otherwise only routes with specified proxy name will be loaded from `ProxyConfigs` table)

Also you can use helper method to keep your yarp db up to date:
```csharp
app.MigrateYarpDb();
```