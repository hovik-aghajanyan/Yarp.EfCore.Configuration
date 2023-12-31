using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Yarp.ReverseProxy.Configuration;

namespace Yarp.EfCore.Configuration.Entities;

public class SessionAffinityCookieConfigEntity:BaseEntity
{
    /// <summary>The cookie path.</summary>
    [StringLength(500)]
    public string? Path { get; init; }

    /// <summary>The domain to associate the cookie with.</summary>
    [StringLength(500)]
    public string? Domain { get; init; }

    /// <summary>
    /// Indicates whether a cookie is accessible by client-side script.
    /// </summary>
    /// <remarks>Defaults to "true".</remarks>
    public bool? HttpOnly { get; init; }

    /// <summary>
    /// The policy that will be used to determine <see cref="P:Microsoft.AspNetCore.Http.CookieOptions.Secure" />.
    /// </summary>
    /// <remarks>Defaults to <see cref="F:Microsoft.AspNetCore.Http.CookieSecurePolicy.None" />.</remarks>
    public CookieSecurePolicy? SecurePolicy { get; init; }

    /// <summary>The SameSite attribute of the cookie.</summary>
    /// <remarks>Defaults to <see cref="F:Microsoft.AspNetCore.Http.SameSiteMode.Unspecified" />.</remarks>
    public SameSiteMode? SameSite { get; init; }

    /// <summary>Gets or sets the lifespan of a cookie.</summary>
    public TimeSpan? Expiration { get; init; }

    /// <summary>Gets or sets the max-age for the cookie.</summary>
    public TimeSpan? MaxAge { get; init; }

    /// <summary>
    /// Indicates if this cookie is essential for the application to function correctly. If true then
    /// consent policy checks may be bypassed.
    /// </summary>
    /// <remarks>Defaults to "false".</remarks>
    public bool? IsEssential { get; init; }

    public SessionAffinityCookieConfig ToConfig()
    {
        return new SessionAffinityCookieConfig
        {
            Domain = Domain,
            Expiration = Expiration,
            HttpOnly = HttpOnly,
            IsEssential = IsEssential,
            MaxAge = MaxAge,
            Path = Path,
            SameSite = SameSite,
            SecurePolicy = SecurePolicy
        };
    }
}