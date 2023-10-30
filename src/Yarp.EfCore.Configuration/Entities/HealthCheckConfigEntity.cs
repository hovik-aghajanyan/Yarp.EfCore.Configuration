using Yarp.ReverseProxy.Configuration;

namespace Yarp.EfCore.Configuration.Entities;

public class HealthCheckConfigEntity
{
    /// <summary>Passive health check config.</summary>
    public PassiveHealthCheckConfigEntity? Passive { get; init; }

    /// <summary>Active health check config.</summary>
    public ActiveHealthCheckConfigEntity? Active { get; init; }

    /// <summary>Available destinations policy.</summary>
    public string? AvailableDestinationsPolicy { get; init; }
}