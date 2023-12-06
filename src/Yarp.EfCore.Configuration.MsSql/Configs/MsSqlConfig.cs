using Yarp.EfCore.Configuration.Base;

namespace Yarp.EfCore.Configuration.MsSql.Configs;

public class MsSqlConfig:BaseProviderConfig
{
    public string ConnectionString { get; set; } = null!;
    public TimeSpan RetryInterval { get; set; } = TimeSpan.FromMilliseconds(1000);
    public int RetryCount { get; set; } = 3;
}