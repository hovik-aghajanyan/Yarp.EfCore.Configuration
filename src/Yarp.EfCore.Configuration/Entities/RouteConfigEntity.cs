using System.ComponentModel.DataAnnotations;
using Yarp.ReverseProxy.Configuration;

namespace Yarp.EfCore.Configuration.Entities;

public class RouteConfigEntity:BaseEntity
{
    /// <summary>
    /// Globally unique identifier of the route.
    /// This field is required.
    /// </summary>
    [StringLength(100)]
    public string RouteId { get; init; } = null!;

    /// <summary>
    /// Parameters used to match requests.
    /// This field is required.
    /// </summary>
    public RouteMatchEntity Match { get; init; } = null!;

    /// <summary>
    /// Optionally, an order value for this route. Routes with lower numbers take precedence over higher numbers.
    /// </summary>
    public int? Order { get; init; } = 1000;

    /// <summary>
    /// Gets or sets the cluster that requests matching this route
    /// should be proxied to.
    /// </summary>
    [StringLength(100)]
    public string? ClusterId { get; init; }

    /// <summary>
    /// The name of the AuthorizationPolicy to apply to this route.
    /// If not set then only the FallbackPolicy will apply.
    /// Set to "Default" to enable authorization with the applications default policy.
    /// Set to "Anonymous" to disable all authorization checks for this route.
    /// </summary>
    [StringLength(100)]
    public string? AuthorizationPolicy { get; init; }

    /// <summary>
    /// The name of the CorsPolicy to apply to this route.
    /// If not set then the route won't be automatically matched for cors preflight requests.
    /// Set to "Default" to enable cors with the default policy.
    /// Set to "Disable" to refuses cors requests for this route.
    /// </summary>
    [StringLength(100)]
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
    
    /// <summary>
    /// The name of the RateLimiterPolicy to apply to this route.
    /// If not set then only the GlobalLimiter will apply.
    /// Set to "Disable" to disable rate limiting for this route.
    /// Set to "Default" or leave empty to use the global rate limits, if any.
    /// </summary>
    [StringLength(100)]
    public string? RateLimiterPolicy { get; init; }

    /// <summary>
    /// The name of the TimeoutPolicy to apply to this route.
    /// Setting both Timeout and TimeoutPolicy is an error.
    /// If not set then only the system default will apply.
    /// Set to "Disable" to disable timeouts for this route.
    /// Set to "Default" or leave empty to use the system defaults, if any.
    /// </summary>
    [StringLength(100)]
    public string? TimeoutPolicy { get; init; }

    /// <summary>
    /// The Timeout to apply to this route. This overrides any system defaults.
    /// Setting both Timeout and TimeoutPolicy is an error.
    /// Timeout granularity is limited to milliseconds.
    /// </summary>
    public TimeSpan? Timeout { get; init; }

    public bool IsEnabled { get; set; }

    public RouteConfig ToConfig()
    {
        return new RouteConfig
        {
            Match = Match.ToConfig(),
            Metadata = Metadata?.ToDictionary(m => m.Key, m => m.Value),
            Order = Order,
            ClusterId = ClusterId,
            AuthorizationPolicy = AuthorizationPolicy,
            CorsPolicy = CorsPolicy,
            MaxRequestBodySize = MaxRequestBodySize,
            Transforms = Transforms?.Select(t => t.TransformConfigs.ToDictionary(c => c.Key, c => c.Value)).ToList(),
            RouteId = RouteId,
            Timeout = Timeout,
            TimeoutPolicy = TimeoutPolicy,
            RateLimiterPolicy = RateLimiterPolicy
        };
    }
}