using Yarp.ReverseProxy.Configuration;

namespace Yarp.EfCore.Configuration.Entities;

public class RouteMatchEntity:BaseEntity
{
    
    /// <summary>
    /// Only match requests that use these optional HTTP methods. E.g. GET, POST.
    /// </summary>
    public List<string>? Methods { get; init; }

    /// <summary>
    /// Only match requests with the given Host header.
    /// Supports wildcards and ports. For unicode host names, do not use punycode.
    /// </summary>
    public List<string>? Hosts { get; init; }

    /// <summary>Only match requests with the given Path pattern.</summary>
    public string? Path { get; init; }

    /// <summary>
    /// Only match requests that contain all of these query parameters.
    /// </summary>
    public List<RouteQueryParameterEntity>? QueryParameters { get; init; }

    /// <summary>
    /// Only match requests that contain all of these headers.
    /// </summary>
    public List<RouteHeaderEntity>? Headers { get; init; }

    public RouteMatch ToConfig()
    {
        return new RouteMatch()
        {
            Path = Path,
            Hosts = Hosts,
            Methods = Methods,
            Headers = Headers?.Select(x => x.ToConfig()).ToList(),
            QueryParameters = QueryParameters?.Select(x => x.ToConfig()).ToList()
        };
    }
}