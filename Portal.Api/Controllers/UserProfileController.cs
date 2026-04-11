using MediatR;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Requests.Endpoints.UserProfile;

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
}
