using System.ComponentModel.DataAnnotations;

namespace Yarp.EfCore.Configuration.Entities;

public class ClusterConfigDestinationEntity:BaseEntity
{
    [StringLength(100)]
    public string Name { get; set; } = null!;
    public ClusterConfigEntity ClusterConfig { get; set; } = null!;
    public DestinationConfigEntity DestinationConfig { get; set; } = null!;
}