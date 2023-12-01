using AutoMapper;
using Yarp.ReverseProxy.Configuration;
using Yarp.ReverseProxy.Forwarder;
using Yarp.EfCore.Configuration.Entities;

namespace Yarp.EfCore.Configuration.Profiles;

public class EntityMappings:Profile
{
    public EntityMappings()
    {
        CreateMap<ActiveHealthCheckConfigEntity, ActiveHealthCheckConfig>().ReverseMap();
        CreateMap<ClusterConfigEntity, ClusterConfig>().ReverseMap();
        
        CreateMap<ClusterConfigDestinationEntity, IReadOnlyDictionary<string,DestinationConfig>>().ReverseMap();
        CreateMap<ClusterConfigMetadataEntity, IReadOnlyDictionary<string,string>>()
            .ReverseMap();
        CreateMap<DestinationConfigMetadataEntity, IReadOnlyDictionary<string,string>>()
            .ReverseMap();
        CreateMap<RouteConfigMetadataEntity, IReadOnlyDictionary<string,string>>()
            .ReverseMap();
        CreateMap<TransformConfigEntity, IReadOnlyDictionary<string,string>>()
            .ReverseMap();
        CreateMap<TransformEntity, IReadOnlyList<IReadOnlyDictionary<string,string>>>()
            .ReverseMap();
        
        CreateMap<DestinationConfigEntity, DestinationConfig>().ReverseMap();
        CreateMap<ForwarderRequestConfigEntity, ForwarderRequestConfig>().ReverseMap();
        CreateMap<HealthCheckConfigEntity, HealthCheckConfig>().ReverseMap();
        CreateMap<HttpClientConfigEntity, HttpClientConfig>().ReverseMap();
        CreateMap<PassiveHealthCheckConfigEntity, PassiveHealthCheckConfig>().ReverseMap();
        CreateMap<RouteConfigEntity, RouteConfig>().ReverseMap();
        CreateMap<RouteHeaderEntity, RouteHeader>().ReverseMap();
        CreateMap<RouteMatchEntity, RouteMatch>().ReverseMap();
        CreateMap<RouteQueryParameterEntity, RouteQueryParameter>().ReverseMap();
        CreateMap<SessionAffinityConfigEntity, SessionAffinityConfig>().ReverseMap();
        CreateMap<SessionAffinityCookieConfigEntity, SessionAffinityCookieConfig>().ReverseMap();
        CreateMap<WebProxyConfigEntity, WebProxyConfig>().ReverseMap();
    }
}