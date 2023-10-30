using Yarp.ReverseProxy.Configuration;
using Yarp.ReverseProxy.Forwarder;

namespace Yarp.EfCore.Configuration.Entities;

public class ClusterConfigEntity
{
    /// <summary>
    /// The Id for this cluster. This needs to be globally unique.
    /// This field is required.
    /// </summary>
    public string ClusterId { get; init; } = null!;

    /// <summary>Load balancing policy.</summary>
    public string? LoadBalancingPolicy { get; init; }

    /// <summary>Session affinity config.</summary>
    public SessionAffinityConfigEntity? SessionAffinity { get; init; }

    /// <summary>Health checking config.</summary>
    public HealthCheckConfigEntity? HealthCheck { get; init; }

    /// <summary>
    /// Config for the HTTP client that is used to call destinations in this cluster.
    /// </summary>
    public HttpClientConfigEntity? HttpClient { get; init; }

    /// <summary>Config for outgoing HTTP requests.</summary>
    public ForwarderRequestConfigEntity? HttpRequest { get; init; }

    /// <summary>The set of destinations associated with this cluster.</summary>
    public IReadOnlyDictionary<string, DestinationConfigEntity>? Destinations { get; init; }

    /// <summary>
    /// Arbitrary key-value pairs that further describe this cluster.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata { get; init; }
}