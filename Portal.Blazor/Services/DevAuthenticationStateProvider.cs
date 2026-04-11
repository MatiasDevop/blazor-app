using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;

namespace Portal.Blazor.Services;

// Minimal dev provider that treats user as unauthenticated by default.
// You can extend to simulate an authenticated user if needed.
public class DevAuthenticationStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal _user = new(new ClaimsIdentity());

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
