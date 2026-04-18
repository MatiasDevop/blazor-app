using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ViewModels.Requests.Endpoints.UserProfile;
using ViewModels.Commands;
using ViewModels.Dtos;

namespace Portal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserProfileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Register a new student user - Public endpoint
    /// </summary>
    [AllowAnonymous]
    [HttpPost("student")]
    [ProducesResponseType(typeof(RegisterStudentResult), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RegisterStudentResult>> RegisterStudent([FromBody] RegisterStudentRequest request)
    {
        var result = await _mediator.Send(request);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return CreatedAtRoute(null, result);
    }

    /// <summary>
    /// Register a new company user - Public endpoint
    /// </summary>
    [AllowAnonymous]
    [HttpPost("company")]
    [ProducesResponseType(typeof(RegisterCompanyResult), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RegisterCompanyResult>> RegisterCompany([FromBody] RegisterCompanyRequest request)
    {
        var result = await _mediator.Send(request);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return CreatedAtRoute(null, result);
    }

    /// <summary>
    /// Register a new career center user - Public endpoint
    /// </summary>
    [AllowAnonymous]
    [HttpPost("careercenter")]
    [ProducesResponseType(typeof(RegisterCareerCenterResult), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RegisterCareerCenterResult>> RegisterCareerCenter([FromBody] RegisterCareerCenterRequest request)
    {
        var result = await _mediator.Send(request);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return CreatedAtRoute(null, result);
    }

    /// <summary>
    /// Get user profile by ID - Requires authentication
    /// </summary>
    [Authorize]
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PartialUserProfileDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<PartialUserProfileDto>> GetUserProfile(Guid id)
    {
        var request = new GetUserProfileRequest(Guid.NewGuid(), id);
        var result = await _mediator.Send(request);

        return Ok(result.UserProfile);
    }

    /// <summary>
    /// Get user profile by email - Requires authentication
    /// </summary>
    [Authorize]
    [HttpGet("email/{email}")]
    [ProducesResponseType(typeof(UserProfileDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserProfileDto>> GetUserByEmail(string email)
    {
        var request = new GetUserForEmailRequest(Guid.NewGuid(), email);
        var result = await _mediator.Send(request);

        if (!result.Found)
        {
            return NotFound(new { message = $"User with email {email} not found" });
        }

        return Ok(result.UserProfile);
    }

    /// <summary>
    /// Update user profile - Requires authentication
    /// </summary>
    [Authorize]
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> UpdateUserProfile(Guid id, [FromBody] UpdateUserProfileCommand command)
    {
        var request = new UpdateUserProfileRequest(Guid.NewGuid(), id, command);
        var result = await _mediator.Send(request);

        return Ok(new { message = result.Message, success = result.Success });
    }

    /// <summary>
    /// Get the profile of the currently authenticated user.
    /// Identified via the email claim in the JWT (or dev auth header).
    /// </summary>
    [Authorize]
    [HttpGet]
    [ProducesResponseType(typeof(FullUserProfileDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<FullUserProfileDto>> GetCurrentUserProfile()
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value
                    ?? User.FindFirst("email")?.Value
                    ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrWhiteSpace(email))
            return Unauthorized(new { message = "No email claim found in token" });

        var result = await _mediator.Send(new GetCurrentUserProfileRequest(Guid.NewGuid(), email));

        if (!result.Found)
            return NotFound(new { message = $"No profile found for {email}" });

        return Ok(result.Profile);
    }

    /// <summary>
    /// Get the companies and schools assigned to the currently authenticated user.
    /// Used by OrgSelectionService to populate the org switcher.
    /// </summary>
    [Authorize]
    [HttpGet("AssignedOrgs")]
    [ProducesResponseType(typeof(GetCompaniesForUserProfileResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetCompaniesForUserProfileResult>> GetAssignedOrgs()
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value
                    ?? User.FindFirst("email")?.Value
                    ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrWhiteSpace(email))
            return Unauthorized(new { message = "No email claim found in token" });

        var result = await _mediator.Send(new GetCompaniesForUserProfileRequest(Guid.NewGuid(), email));
        return Ok(result);
    }

    /// <summary>
    /// Get a list of employee-type user profiles (used on landing page spotlight).
    /// </summary>
    [AllowAnonymous]
    [HttpGet("Employees/{count:int}")]
    [ProducesResponseType(typeof(IEnumerable<ViewModels.ViewModels.UserLabelVm>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ViewModels.ViewModels.UserLabelVm>>> GetEmployees(int count = 4)
    {
        var employees = await _mediator.Send(new GetEmployeesRequest(Guid.NewGuid(), count));
        return Ok(employees.Employees);
    }
}
