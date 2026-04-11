using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portal.Api.Controllers;

/// <summary>
/// Base controller with authentication required
/// </summary>
[Authorize]
[ApiController]
public abstract class AuthorizedControllerBase : ControllerBase
{
    protected Guid GetUserId()
    {
        var userIdClaim = User.FindFirst("sub") ?? User.FindFirst("user_id");
        if (userIdClaim != null && Guid.TryParse(userIdClaim.Value, out var userId))
        {
            return userId;
        }
        throw new UnauthorizedAccessException("User ID not found in token");
    }

    protected string GetUserEmail()
    {
        var emailClaim = User.FindFirst("email");
        if (emailClaim != null)
        {
            return emailClaim.Value;
        }
        throw new UnauthorizedAccessException("Email not found in token");
    }

    protected bool IsInRole(string role)
    {
        return User.HasClaim("role", role);
    }
}
