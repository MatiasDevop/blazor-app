using System.Security.Claims;

namespace Portal.Api.Middleware;

/// <summary>
/// Development-only middleware that injects a fake authenticated user when no
/// Authorization header is present. Allows the Blazor dev client (which uses
/// DevAuthenticationStateProvider without a real JWT) to reach [Authorize] endpoints.
/// Never registered in Production.
/// </summary>
public class DevAuthMiddleware
{
    private const string DevEmail = "dev@cpcc.local";
    private readonly RequestDelegate _next;

    public DevAuthMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.ContainsKey("Authorization"))
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, DevEmail),
                new Claim(ClaimTypes.Email, DevEmail),
                new Claim(ClaimTypes.NameIdentifier, DevEmail),
                new Claim("email", DevEmail),
            };
            var identity = new ClaimsIdentity(claims, "DevAuth");
            context.User = new ClaimsPrincipal(identity);
        }

        await _next(context);
    }
}
