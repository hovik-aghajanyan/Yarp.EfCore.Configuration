namespace Yarp.EfCore.Configuration.Entities;

public class ClusterConfigDestinationEntity:BaseEntity
{
    public string Name { get; set; } = null!;
    public ClusterConfigEntity ClusterConfig { get; set; } = null!;
    public DestinationConfigEntity DestinationConfig { get; set; } = null!;
}