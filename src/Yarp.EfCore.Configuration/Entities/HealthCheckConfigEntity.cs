using System.ComponentModel.DataAnnotations;
using Yarp.ReverseProxy.Configuration;

namespace Yarp.EfCore.Configuration.Entities;

public class HealthCheckConfigEntity:BaseEntity
{
    /// <summary>Passive health check config.</summary>
    public PassiveHealthCheckConfigEntity? Passive { get; init; }

    /// <summary>Active health check config.</summary>
    public ActiveHealthCheckConfigEntity? Active { get; init; }

    /// <summary>Available destinations policy.</summary>
    [StringLength(100)]
    public string? AvailableDestinationsPolicy { get; init; }

    public HealthCheckConfig ToConfig()
    {
        return new HealthCheckConfig
        {
            AvailableDestinationsPolicy = AvailableDestinationsPolicy,
            Passive = Passive?.ToConfig(),
            Active = Active?.ToConfig()
        };
    }
}