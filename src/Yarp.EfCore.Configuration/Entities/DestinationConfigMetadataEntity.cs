namespace Yarp.EfCore.Configuration.Entities;

public class DestinationConfigMetadataEntity:BaseEntity
{
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
}