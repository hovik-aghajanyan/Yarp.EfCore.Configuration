using Yarp.ReverseProxy.Configuration;

namespace Yarp.EfCore.Configuration.Entities;

public class RouteConfigEntity:BaseEntity
{
    /// <summary>
    /// Globally unique identifier of the route.
    /// This field is required.
    /// </summary>
    public string RouteId { get; init; } = null!;

    /// <summary>
    /// Parameters used to match requests.
    /// This field is required.
    /// </summary>
    public RouteMatch Match { get; init; } = null!;

    /// <summary>
    /// Optionally, an order value for this route. Routes with lower numbers take precedence over higher numbers.
    /// </summary>
    public int? Order { get; init; } = 1000;

    /// <summary>
    /// Gets or sets the cluster that requests matching this route
    /// should be proxied to.
    /// </summary>
    public string? ClusterId { get; init; }

    public ClusterConfigEntity? Cluster { get; set; }

    /// <summary>
    /// The name of the AuthorizationPolicy to apply to this route.
    /// If not set then only the FallbackPolicy will apply.
    /// Set to "Default" to enable authorization with the applications default policy.
    /// Set to "Anonymous" to disable all authorization checks for this route.
    /// </summary>
    public string? AuthorizationPolicy { get; init; }

    /// <summary>
    /// The name of the CorsPolicy to apply to this route.
    /// If not set then the route won't be automatically matched for cors preflight requests.
    /// Set to "Default" to enable cors with the default policy.
    /// Set to "Disable" to refuses cors requests for this route.
    /// </summary>
    public string? CorsPolicy { get; init; }

    /// <summary>
    /// An optional override for how large request bodies can be in bytes. If set, this overrides the server's default (30MB) per request.
    /// Set to '-1' to disable the limit for this route.
    /// </summary>
    public long? MaxRequestBodySize { get; init; }

    /// <summary>
    /// Arbitrary key-value pairs that further describe this route.
    /// </summary>
    public ICollection<RouteConfigMetadataEntity>? Metadata { get; init; }

    /// <summary>
    /// Parameters used to transform the request and response. See <see cref="T:Yarp.ReverseProxy.Transforms.Builder.ITransformBuilder" />.
    /// </summary>
    public ICollection<TransformEntity>? Transforms { get; init; }

    public bool IsEnabled { get; set; }
}