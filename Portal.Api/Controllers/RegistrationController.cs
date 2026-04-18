using Domain.Entities;
using Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using ViewModels.Commands;
using ViewModels.Queries;
using ViewModels.Requests.Endpoints.UserProfile;

namespace Portal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegistrationController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<RegistrationController> _logger;

    public RegistrationController(ApplicationDbContext context, ILogger<RegistrationController> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Check whether an email address is already registered.
    /// </summary>
    [AllowAnonymous]
    [HttpGet("EmailExists")]
    [ProducesResponseType(typeof(EmailExistsQueryResult), StatusCodes.Status200OK)]
    public async Task<ActionResult<EmailExistsQueryResult>> EmailExists([FromQuery] string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return BadRequest(new { message = "email is required" });

        var exists = await _context.UserProfiles
            .AnyAsync(u => u.Email.ToLower() == email.Trim().ToLowerInvariant());

        return Ok(new EmailExistsQueryResult { Email = email, Exists = exists });
    }

    /// <summary>
    /// Register a new employee (individual professional) user.
    /// Delegates to the same pattern used by student/company registration.
    /// </summary>
    [AllowAnonymous]
    [HttpPost("Employees")]
    [ProducesResponseType(typeof(RegisterEmployeeCommandResult), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RegisterEmployeeCommandResult>> RegisterEmployee([FromBody] RegisterEmployeeCommand command)
    {
        var emailExists = await _context.UserProfiles
            .AnyAsync(u => u.Email.ToLower() == command.EmailAddress.Trim().ToLowerInvariant());

        if (emailExists)
            return Conflict(new { message = "Email address is already registered" });

        var userProfile = new UserProfile
        {
            Id = Guid.NewGuid(),
            Email = command.EmailAddress.Trim().ToLowerInvariant(),
            FirstName = command.FirstName,
            LastName = command.LastName,
            CreatedAt = DateTime.UtcNow,
            ProfileType = ProfileType.Mentor,
        };

        _context.UserProfiles.Add(userProfile);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Registered employee {UserId} ({Email})", userProfile.Id, userProfile.Email);

        return CreatedAtRoute(null, new RegisterEmployeeCommandResult
        {
            UserId = userProfile.Id,
        });
    }

    /// <summary>
    /// Look up a discount code for registration.
    /// </summary>
    [AllowAnonymous]
    [HttpGet("Discount")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetDiscount([FromQuery] string code, [FromQuery] string targetType, [FromQuery] Guid? target)
    {
        if (string.IsNullOrWhiteSpace(code))
            return BadRequest(new { message = "code is required" });

        var discount = await _context.Discounts
            .FirstOrDefaultAsync(d => d.Code == code);

        if (discount == null)
            return NotFound(new { message = "Discount code not found or expired" });

        return Ok(new
        {
            discount.Id,
            discount.Code,
            discount.Amount,
        });
    }
}
