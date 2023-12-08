using System.ComponentModel.DataAnnotations;
using Yarp.ReverseProxy.Configuration;

namespace Yarp.EfCore.Configuration.Entities;

public class ClusterConfigEntity:BaseEntity
{
    /// <summary>
    /// The Id for this cluster. This needs to be globally unique.
    /// This field is required.
    /// </summary>
    [StringLength(100)]
    public string ClusterId { get; init; } = null!;

    /// <summary>Load balancing policy.</summary>
    [StringLength(100)]
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
    public ICollection<ClusterConfigDestinationEntity>? Destinations { get; init; }

    /// <summary>
    /// Arbitrary key-value pairs that further describe this cluster.
    /// </summary>
    public ICollection<ClusterConfigMetadataEntity>? Metadata { get; init; }

    public ClusterConfig ToConfig()
    {
        return new ClusterConfig
        {
            ClusterId = ClusterId,
            LoadBalancingPolicy = LoadBalancingPolicy,
            Destinations = Destinations?.ToDictionary(d => d.Name, d => d.DestinationConfig.ToConfig()),
            HealthCheck = HealthCheck?.ToConfig(),
            HttpClient = HttpClient?.ToConfig(),
            HttpRequest = HttpRequest?.ToConfig(),
            Metadata = Metadata?.ToDictionary(m => m.Key, m => m.Value),
            SessionAffinity = SessionAffinity?.ToConfig()
        };
    }
}