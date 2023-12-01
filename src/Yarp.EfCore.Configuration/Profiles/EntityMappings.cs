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
        
        CreateMap<ClusterConfigDestinationEntity, KeyValuePair<string,DestinationConfig>>()
            .ForMember(p => p.Key, opt => opt.MapFrom(p => p.Name))
            .ForMember(p => p.Value, opt => opt.MapFrom(p => p.DestinationConfig))
            .ReverseMap()
            .ForMember(p => p.Name, opt => opt.MapFrom(p => p.Key))
            .ForMember(p => p.DestinationConfig, opt => opt.MapFrom(p => p.Value));
        CreateMap<ClusterConfigMetadataEntity, KeyValuePair<string, string>>()
            .ReverseMap();
        CreateMap<DestinationConfigMetadataEntity, KeyValuePair<string, string>>()
            .ReverseMap();
        CreateMap<RouteConfigMetadataEntity, KeyValuePair<string, string>>()
            .ReverseMap();
        CreateMap<TransformConfigEntity, KeyValuePair<string, string>>()
            .ReverseMap();
        CreateMap<TransformEntity, IReadOnlyDictionary<string,string>>()
            //ToDo: Complete this mapping
            .ReverseMap();
        CreateMap<Version, string>()
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