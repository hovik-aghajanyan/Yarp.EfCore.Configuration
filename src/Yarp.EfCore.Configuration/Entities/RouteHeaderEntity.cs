using Yarp.ReverseProxy.Configuration;

namespace Yarp.EfCore.Configuration.Entities;

public class RouteHeaderEntity:BaseEntity
{
    /// <summary>
    /// Name of the header to look for.
    /// This field is case insensitive and required.
    /// </summary>
    public string Name { get; init; } = null!;

    /// <summary>
    /// A collection of acceptable header values used during routing. Only one value must match.
    /// The list must not be empty unless using <see cref="F:Yarp.ReverseProxy.Configuration.HeaderMatchMode.Exists" /> or <see cref="F:Yarp.ReverseProxy.Configuration.HeaderMatchMode.NotExists" />.
    /// </summary>
    public List<string>? Values { get; init; }

    /// <summary>
    /// Specifies how header values should be compared (e.g. exact matches Vs. by prefix).
    /// Defaults to <see cref="F:Yarp.ReverseProxy.Configuration.HeaderMatchMode.ExactHeader" />.
    /// </summary>
    public HeaderMatchMode Mode { get; init; }

    /// <summary>
    /// Specifies whether header value comparisons should ignore case.
    /// When <c>true</c>, <see cref="F:System.StringComparison.Ordinal" /> is used.
    /// When <c>false</c>, <see cref="F:System.StringComparison.OrdinalIgnoreCase" /> is used.
    /// Defaults to <c>false</c>.
    /// </summary>
    public bool IsCaseSensitive { get; init; }
}