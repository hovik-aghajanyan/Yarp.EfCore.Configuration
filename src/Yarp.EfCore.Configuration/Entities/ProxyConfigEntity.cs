using Yarp.ReverseProxy.Configuration;

namespace Yarp.EfCore.Configuration.Entities;

public class ProxyConfigEntity:BaseEntity
{
    public string Name { get; set; } = null!;
    public int RouteConfigId { get; set; }
    public RouteConfigEntity RouteConfig { get; set; } = null!;
}