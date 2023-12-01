namespace Yarp.EfCore.Configuration.Base;

public class BaseProviderConfig
{
    /// <summary>
    /// If Interval not specified then the configuration will not be updated automatically
    /// </summary>
    public TimeSpan? CheckUpdateInterval { get; set; } = null;
}