using MediatR;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Requests.Endpoints.JobPosts;
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

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(JobPostDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<JobPostDto>> GetJobPost(Guid id, [FromQuery] bool showInactive = false)
    {
        var request = new GetJobPostRequest(Guid.NewGuid(), id, showInactive);
        var result = await _mediator.Send(request);

        return Ok(result.JobPost);
    }

    [HttpPost]
    [ProducesResponseType(typeof(JobPostDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<JobPostDto>> CreateJobPost([FromBody] CreateJobPostAction action)
    {
        var request = new CreateJobPostRequest(Guid.NewGuid(), action);
        var result = await _mediator.Send(request);

        return CreatedAtAction(nameof(GetJobPost), new { id = result.JobPost.Id }, result.JobPost);
    }
}
