using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Requests.Endpoints.JobPosts;
using ViewModels.Requests.DataAccess.JobPosts;
using ViewModels.HttpRequests.JobPosts;
using ViewModels.Dtos;

namespace Portal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobPostsController : ControllerBase
{
    private readonly IMediator _mediator;

    public JobPostsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get job post by ID - Public endpoint
    /// </summary>
    [AllowAnonymous]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(JobPostDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<JobPostDto>> GetJobPost(Guid id, [FromQuery] bool showInactive = false)
    {
        var request = new GetJobPostRequest(Guid.NewGuid(), id, showInactive);
        var result = await _mediator.Send(request);

        return Ok(result.JobPost);
    }

    /// <summary>
    /// Create a new job post - Requires recruiter or admin role
    /// </summary>
    [Authorize(Policy = "RequireRecruiterRole")]
    [HttpPost]
    [ProducesResponseType(typeof(JobPostDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<JobPostDto>> CreateJobPost([FromBody] CreateJobPostAction action)
    {
        var request = new CreateJobPostRequest(Guid.NewGuid(), action);
        var result = await _mediator.Send(request);

        return CreatedAtAction(nameof(GetJobPost), new { id = result.JobPost.Id }, result.JobPost);
    }

    /// <summary>
    /// Search and filter job posts - Public endpoint
    /// </summary>
    [AllowAnonymous]
    [HttpPost("search")]
    [ProducesResponseType(typeof(List<JobPostDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<JobPostDto>>> SearchJobPosts([FromBody] SearchJobsAction action)
    {
        var request = new SearchJobPostsRequest(Guid.NewGuid(), action);
        var result = await _mediator.Send(request);

        return Ok(result.JobPosts);
    }

    /// <summary>
    /// Update an existing job post - Requires recruiter or admin role
    /// </summary>
    [Authorize(Policy = "RequireRecruiterRole")]
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(EditJobPostAction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<EditJobPostAction>> UpdateJobPost(Guid id, [FromBody] EditJobPostAction action)
    {
        if (id != action.Id)
        {
            return BadRequest(new { message = "Job post ID in URL does not match body" });
        }

        var request = new UpdateJobPostRequest(Guid.NewGuid(), action);
        var result = await _mediator.Send(request);

        return Ok(result.UpdateJobPost);
    }

    /// <summary>
    /// Delete a job post (soft delete) - Requires recruiter or admin role
    /// </summary>
    [Authorize(Policy = "RequireRecruiterRole")]
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> DeleteJobPost(Guid id)
    {
        var request = new DeleteJobPostRequest(Guid.NewGuid(), id);
        var result = await _mediator.Send(request);

        return Ok(new { message = result.Message, success = result.Success });
    }

    /// <summary>
    /// Get recommended job posts for a student - Requires authentication
    /// </summary>
    [Authorize]
    [HttpGet("recommended/{userId:guid}")]
    [ProducesResponseType(typeof(List<JobPostDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<List<JobPostDto>>> GetRecommendedJobs(
        Guid userId,
        [FromQuery] int page = 1,
        [FromQuery] int size = 10)
    {
        var request = new GetRecommendedJobsRequest(Guid.NewGuid(), userId, page, size);
        var result = await _mediator.Send(request);

        return Ok(new
        {
            jobs = result.Jobs,
            totalCount = result.TotalCount,
            page = page,
            size = size
        });
    }
}
