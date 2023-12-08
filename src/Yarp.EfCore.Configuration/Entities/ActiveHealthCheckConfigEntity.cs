using System.ComponentModel.DataAnnotations;
using Yarp.ReverseProxy.Configuration;

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
    [StringLength(100)]
    public string? Policy { get; init; }

    /// <summary>HTTP health check endpoint path.</summary>
    [StringLength(500)]
    public string? Path { get; init; }

    public ActiveHealthCheckConfig ToConfig()
    {
        return new ActiveHealthCheckConfig
        {
            Enabled = Enabled,
            Policy = Policy,
            Interval = Interval,
            Path = Path,
            Timeout = Timeout
        };
    }
}