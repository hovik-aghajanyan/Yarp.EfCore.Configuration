using Yarp.ReverseProxy.Configuration;

namespace Yarp.EfCore.Configuration.Entities;

public class HttpClientConfigEntity
{
    /// <summary>What TLS protocols to use.</summary>
    public System.Security.Authentication.SslProtocols? SslProtocols { get; init; }

    /// <summary>
    /// Indicates if destination server https certificate errors should be ignored.
    /// This should only be done when using self-signed certificates.
    /// </summary>
    public bool? DangerousAcceptAnyServerCertificate { get; init; }

    /// <summary>
    /// Limits the number of connections used when communicating with the destination server.
    /// </summary>
    public int? MaxConnectionsPerServer { get; init; }

    /// <summary>
    /// Optional web proxy used when communicating with the destination server.
    /// </summary>
    public WebProxyConfigEntity? WebProxy { get; init; }

    /// <summary>
    /// Gets or sets a value that indicates whether additional HTTP/2 connections can
    /// be established to the same server when the maximum number of concurrent streams
    /// is reached on all existing connections.
    /// </summary>
    public bool? EnableMultipleHttp2Connections { get; init; }

    /// <summary>
    /// Enables non-ASCII header encoding for outgoing requests.
    /// </summary>
    public string? RequestHeaderEncoding { get; init; }
}