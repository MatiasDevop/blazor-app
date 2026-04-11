using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Requests.Endpoints.JobApplications;
using ViewModels.Dtos;

namespace Portal.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class JobApplicationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public JobApplicationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get all job applications for a user - Requires authentication
    /// </summary>
    [HttpGet("user/{userId}")]
    [ProducesResponseType(typeof(IEnumerable<JobApplicationDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<IEnumerable<JobApplicationDto>>> GetJobApplicationsForUser(Guid userId)
    {
        var request = new GetJobApplicationsForUserRequest(Guid.NewGuid(), userId);
        var result = await _mediator.Send(request);

        return Ok(result.JobApplications);
    }

    /// <summary>
    /// Create a new job application - Requires authentication
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(JobApplicationDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<JobApplicationDto>> CreateJobApplication([FromBody] JobApplicationDto applicationDto)
    {
        var request = new CreateJobApplicationRequest(Guid.NewGuid(), applicationDto);
        var result = await _mediator.Send(request);

        return CreatedAtAction(nameof(GetJobApplicationsForUser),
            new { userId = result.JobApplication.ApplicantId },
            result.JobApplication);
    }
}
