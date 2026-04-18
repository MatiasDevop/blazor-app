using System.Security.Claims;
using System.Text.Json;
using Constants;
using Microsoft.AspNetCore.Components.Authorization;

namespace Portal.Blazor.Services;

// Dev provider that auto-authenticates as a local dev user so [Authorize] pages work.
public class DevAuthenticationStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal _user;

    public DevAuthenticationStateProvider()
    {
        // Auto-authenticate with a dev identity so all [Authorize] pages are accessible
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, "dev@cpcc.local"),
            new(ClaimTypes.Email, "dev@cpcc.local"),
            new(AppechClaimTypes.Email, "dev@cpcc.local"),
        };
        _user = new ClaimsPrincipal(new ClaimsIdentity(claims, authenticationType: "DevAuth"));
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(new AuthenticationState(_user));
    }

    public void SetAuthenticated(string name, IEnumerable<Claim>? extraClaims = null)
    {
        var claims = new List<Claim> { new(ClaimTypes.Name, name) };
        if (extraClaims != null) claims.AddRange(extraClaims);
        _user = new ClaimsPrincipal(new ClaimsIdentity(claims, authenticationType: "DevAuth"));
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public void SetAnonymous()
    {
        _user = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
