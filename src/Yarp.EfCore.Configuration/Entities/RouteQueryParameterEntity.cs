using Yarp.ReverseProxy.Configuration;

namespace Yarp.EfCore.Configuration.Entities;

public class RouteQueryParameterEntity
{
    /// <summary>
    /// Name of the query parameter to look for.
    /// This field is case insensitive and required.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// A collection of acceptable query parameter values used during routing.
    /// </summary>
    public IReadOnlyList<string>? Values { get; init; }

    /// <summary>
    /// Specifies how query parameter values should be compared (e.g. exact matches Vs. contains).
    /// Defaults to <see cref="F:Yarp.ReverseProxy.Configuration.QueryParameterMatchMode.Exact" />.
    /// </summary>
    public QueryParameterMatchMode Mode { get; init; }

    /// <summary>
    /// Specifies whether query parameter value comparisons should ignore case.
    /// When <c>true</c>, <see cref="F:System.StringComparison.Ordinal" /> is used.
    /// When <c>false</c>, <see cref="F:System.StringComparison.OrdinalIgnoreCase" /> is used.
    /// Defaults to <c>false</c>.
    /// </summary>
    public bool IsCaseSensitive { get; init; }
}