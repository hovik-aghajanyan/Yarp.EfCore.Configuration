using Yarp.EfCore.Configuration.Entities;
using Yarp.ReverseProxy.Configuration;
using Yarp.ReverseProxy.Forwarder;

namespace Yarp.EfCore.Configuration.Extensions;

public static class ConfigEntityExtensions
{
    public static RouteConfigEntity ToEntity(this RouteConfig config)
    {
        return new RouteConfigEntity
        {
            Transforms = config.Transforms?.Select(t => new TransformEntity()
                {
                    TransformConfigs = t.Select(c => new TransformConfigEntity() {Key = c.Key, Value = c.Value})
                        .ToList()
                })
                .ToList(),
            Order = config.Order,
            ClusterId = config.ClusterId,
            AuthorizationPolicy = config.AuthorizationPolicy,
            CorsPolicy = config.CorsPolicy,
            MaxRequestBodySize = config.MaxRequestBodySize,
            TimeoutPolicy = config.TimeoutPolicy,
            RateLimiterPolicy = config.RateLimiterPolicy,
            RouteId = config.RouteId,
            Timeout = config.Timeout,
            Metadata = config.Metadata?.Select(m => new RouteConfigMetadataEntity(){Key = m.Key, Value = m.Value}).ToList(),
            Match = config.Match.ToEntity()
        };
    }

    public static ClusterConfigEntity ToEntity(this ClusterConfig config)
    {
        return new ClusterConfigEntity()
        {
            Metadata = config.Metadata?.Select(m => new ClusterConfigMetadataEntity() {Key = m.Key, Value = m.Value})
                .ToList(),
            ClusterId = config.ClusterId,
            LoadBalancingPolicy = config.LoadBalancingPolicy,
            HealthCheck = config.HealthCheck?.ToEntity(),
            SessionAffinity = config.SessionAffinity?.ToEntity(),
            HttpRequest = config.HttpRequest?.ToEntity(),
            HttpClient = config.HttpClient?.ToEntity(),
            Destinations = config.Destinations.Select(d => new ClusterConfigDestinationEntity()
            {
                Name = d.Key,
                DestinationConfig = new DestinationConfigEntity()
                {
                    Address = d.Value.Address,
                    Health = d.Value.Health,
                    Metadata = d.Value.Metadata?.Select(m => new DestinationConfigMetadataEntity()
                        {Key = m.Key, Value = m.Value}).ToList(),
                    Host = d.Value.Host
                }
            }).ToList()
        };
    }

    public static HttpClientConfigEntity ToEntity(this HttpClientConfig config)
    {
        return new HttpClientConfigEntity()
        {
            SslProtocols = config.SslProtocols,
            RequestHeaderEncoding = config.RequestHeaderEncoding,
            EnableMultipleHttp2Connections = config.EnableMultipleHttp2Connections,
            MaxConnectionsPerServer = config.MaxConnectionsPerServer,
            DangerousAcceptAnyServerCertificate = config.DangerousAcceptAnyServerCertificate,
            WebProxy = new WebProxyConfigEntity
            {
                Address = config.WebProxy?.Address, BypassOnLocal = config.WebProxy?.BypassOnLocal,
                UseDefaultCredentials = config.WebProxy?.UseDefaultCredentials
            },
        };
    }
    
    public static ForwarderRequestConfigEntity ToEntity(this ForwarderRequestConfig config)
    {
        return new ForwarderRequestConfigEntity()
        {
            Version = config.Version?.ToString(),
            VersionPolicy = config.VersionPolicy,
            ActivityTimeout = config.ActivityTimeout,
            AllowResponseBuffering = config.AllowResponseBuffering
        };
    }
    
    public static SessionAffinityConfigEntity ToEntity(this SessionAffinityConfig config)
    {
        return new SessionAffinityConfigEntity()
        {
            Enabled = config.Enabled,
            FailurePolicy = config.FailurePolicy,
            Policy = config.Policy,
            AffinityKeyName = config.AffinityKeyName,
            Cookie = config.Cookie?.ToEntity()
        };
    }
    
    public static SessionAffinityCookieConfigEntity ToEntity(this SessionAffinityCookieConfig config)
    {
        return new SessionAffinityCookieConfigEntity()
        {
            Domain = config.Domain,
            HttpOnly = config.HttpOnly,
            IsEssential = config.IsEssential,
            MaxAge = config.MaxAge,
            Path = config.Path,
            SameSite = config.SameSite,
            Expiration = config.Expiration,
            SecurePolicy = config.SecurePolicy
        };
    }
    
    public static HealthCheckConfigEntity ToEntity(this HealthCheckConfig config)
    {
        return new HealthCheckConfigEntity()
        {
            Active = config.Active?.ToEntity(),
            Passive = config.Passive?.ToEntity(),
            AvailableDestinationsPolicy = config.AvailableDestinationsPolicy
        };
    }
    
    public static ActiveHealthCheckConfigEntity ToEntity(this ActiveHealthCheckConfig config)
    {
        return new ActiveHealthCheckConfigEntity()
        {
            Enabled = config.Enabled,
            Interval = config.Interval,
            Timeout = config.Timeout,
            Path = config.Path,
            Policy = config.Policy
        };
    }
    
    public static PassiveHealthCheckConfigEntity ToEntity(this PassiveHealthCheckConfig config)
    {
        return new PassiveHealthCheckConfigEntity()
        {
            Enabled = config.Enabled,
            Policy = config.Policy,
            ReactivationPeriod = config.ReactivationPeriod,
        };
    }

    public static RouteMatchEntity ToEntity(this RouteMatch config)
    {
        return new RouteMatchEntity()
        {
            Hosts = config.Hosts?.ToList(),
            Methods = config.Methods?.ToList(),
            Path = config.Path,
            Headers = config.Headers?.Select(h => new RouteHeaderEntity()
                    {Values = h.Values?.ToList(), Name = h.Name, Mode = h.Mode, IsCaseSensitive = h.IsCaseSensitive})
                .ToList(),
            QueryParameters = config.QueryParameters?.Select(q => new RouteQueryParameterEntity()
                    {Values = q.Values?.ToList(), Name = q.Name, Mode = q.Mode, IsCaseSensitive = q.IsCaseSensitive})
                .ToList()
        };
    }
}