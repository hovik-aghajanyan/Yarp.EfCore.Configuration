namespace Yarp.EfCore.Configuration.Entities;

public class TransformEntity:BaseEntity
{
    public RouteConfigEntity RouteConfig { get; set; } = null!;
    public ICollection<TransformConfigEntity> TransformConfigs { get; set; } = null!;
}