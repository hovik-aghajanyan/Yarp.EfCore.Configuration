namespace Yarp.EfCore.Configuration.Entities;

public class PassiveHealthCheckConfigEntity:BaseEntity
{
    /// <summary>Whether passive health checks are enabled.</summary>
    public bool? Enabled { get; init; }

    /// <summary>Passive health check policy.</summary>
    public string? Policy { get; init; }

    /// <summary>
    /// Destination reactivation period after which an unhealthy destination is considered healthy again.
    /// </summary>
    public TimeSpan? ReactivationPeriod { get; init; }
}