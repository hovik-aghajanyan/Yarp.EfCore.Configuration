namespace Yarp.EfCore.Configuration.Entities;

public class RouterConfigTransformConfigMappingEntity:BaseEntity
{
    public RouteConfigEntity RouteConfigEntity { get; set; } = null!;
    public ICollection<TransformConfigEntity> TransformConfigEntities { get; set; } = null!;
}