using Yarp.ReverseProxy.Configuration;

namespace Yarp.EfCore.Configuration.Entities;

public class WebProxyConfigEntity:BaseEntity
{
    /// <summary>The URI of the proxy server.</summary>
    public Uri? Address { get; init; }

    /// <summary>
    /// true to bypass the proxy for local addresses; otherwise, false.
    /// If null, default value will be used: false
    /// </summary>
    public bool? BypassOnLocal { get; init; }

    /// <summary>
    /// Controls whether the <seealso cref="P:System.Net.CredentialCache.DefaultCredentials" /> are sent with requests.
    /// If null, default value will be used: false
    /// </summary>
    public bool? UseDefaultCredentials { get; init; }

    public WebProxyConfig ToConfig()
    {
        return new WebProxyConfig
        {
            Address = Address,
            BypassOnLocal = BypassOnLocal,
            UseDefaultCredentials = UseDefaultCredentials
        };
    }
}