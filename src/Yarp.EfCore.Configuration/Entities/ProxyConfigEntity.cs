using System.ComponentModel.DataAnnotations;

namespace Yarp.EfCore.Configuration.Entities;

public class ProxyConfigEntity:BaseEntity
{
    [StringLength(100)]
    public string Name { get; set; } = null!;
    public int RouteConfigId { get; set; }
    public RouteConfigEntity RouteConfig { get; set; } = null!;
}