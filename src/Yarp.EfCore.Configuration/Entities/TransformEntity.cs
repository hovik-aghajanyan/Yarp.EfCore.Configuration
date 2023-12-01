namespace Yarp.EfCore.Configuration.Entities;

public class TransformEntity:BaseEntity
{
    public ICollection<TransformConfigEntity> Configs { get; set; } = null!;
}