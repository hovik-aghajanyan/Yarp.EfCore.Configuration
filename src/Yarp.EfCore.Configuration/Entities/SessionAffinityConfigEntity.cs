using Yarp.ReverseProxy.Configuration;

namespace Yarp.EfCore.Configuration.Entities;

public class SessionAffinityConfigEntity:BaseEntity
{
    /// <summary>Indicates whether session affinity is enabled.</summary>
    public bool? Enabled { get; init; }

    /// <summary>The session affinity policy to use.</summary>
    public string? Policy { get; init; }

    /// <summary>
    /// Strategy handling missing destination for an affinitized request.
    /// </summary>
    public string? FailurePolicy { get; init; }

    /// <summary>
    /// Identifies the name of the field where the affinity value is stored.
    /// For the cookie affinity policy this will be the cookie name.
    /// For the header affinity policy this will be the header name.
    /// The policy will give its own default if no value is set.
    /// This value should be unique across clusters to avoid affinity conflicts.
    /// https://github.com/microsoft/reverse-proxy/issues/976
    /// This field is required.
    /// </summary>
    public string AffinityKeyName { get; init; }

    /// <summary>
    /// Configuration of a cookie storing the session affinity key in case
    /// the <see cref="P:Yarp.ReverseProxy.Configuration.SessionAffinityConfig.Policy" /> is set to 'Cookie'.
    /// </summary>
    public SessionAffinityCookieConfigEntity? Cookie { get; init; }

    public SessionAffinityConfig ToConfig()
    {
        return new SessionAffinityConfig()
        {
            FailurePolicy = FailurePolicy,
            Policy = Policy,
            AffinityKeyName = AffinityKeyName,
            Cookie = Cookie?.ToConfig(),
            Enabled = Enabled
        };
    }
}