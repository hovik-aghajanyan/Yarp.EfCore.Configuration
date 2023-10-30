using Microsoft.AspNetCore.Http;

namespace Yarp.EfCore.Configuration.Entities;

public class SessionAffinityCookieConfigEntity
{
    /// <summary>The cookie path.</summary>
    public string? Path { get; init; }

    /// <summary>The domain to associate the cookie with.</summary>
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
}