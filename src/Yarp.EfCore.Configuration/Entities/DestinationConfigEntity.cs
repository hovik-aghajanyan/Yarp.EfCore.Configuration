using Yarp.ReverseProxy.Configuration;

namespace Yarp.EfCore.Configuration.Entities;

public class DestinationConfigEntity:BaseEntity
{
    /// <summary>
    /// Address of this destination. E.g. <c>https://127.0.0.1:123/abcd1234/</c>.
    /// This field is required.
    /// </summary>
    public string Address { get; init; }

    /// <summary>
    /// Endpoint accepting active health check probes. E.g. <c>http://127.0.0.1:1234/</c>.
    /// </summary>
    public string? Health { get; init; }

    /// <summary>
    /// Arbitrary key-value pairs that further describe this destination.
    /// </summary>
    public ICollection<DestinationConfigMetadataEntity>? Metadata { get; init; }

    public string? Host { get; set; }

    public DestinationConfig ToConfig()
    {
        return new DestinationConfig
        {
            Address = Address,
            Health = Health,
            Metadata = Metadata?.ToDictionary(m => m.Key, m => m.Value),
            Host = Host
        };
    }
}