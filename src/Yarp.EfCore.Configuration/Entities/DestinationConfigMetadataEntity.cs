using System.ComponentModel.DataAnnotations;

namespace Yarp.EfCore.Configuration.Entities;

public class DestinationConfigMetadataEntity:BaseEntity
{
    [StringLength(100)]
    public string Key { get; set; } = null!;
    [StringLength(500)]
    public string Value { get; set; } = null!;
}