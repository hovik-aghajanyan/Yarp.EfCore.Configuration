namespace Yarp.EfCore.Configuration.Entities;

public class ActiveHealthCheckConfigEntity:BaseEntity
{
    /// <summary>Whether active health checks are enabled.</summary>
    public bool? Enabled { get; init; }

    /// <summary>Health probe interval.</summary>
    public TimeSpan? Interval { get; init; }

    /// <summary>
    /// Health probe timeout, after which a destination is considered unhealthy.
    /// </summary>
    public TimeSpan? Timeout { get; init; }

    /// <summary>Active health check policy.</summary>
    public string? Policy { get; init; }

    /// <summary>HTTP health check endpoint path.</summary>
    public string? Path { get; init; }
}