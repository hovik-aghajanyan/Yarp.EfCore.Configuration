namespace Yarp.EfCore.Configuration.Entities;

public class ClusterConfigMetadataEntity:BaseEntity
{
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
}