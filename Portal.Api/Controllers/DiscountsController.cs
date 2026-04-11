using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Requests.Endpoints.Discounts;

namespace Portal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAdminRole")]
public class DiscountsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DiscountsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Create a new discount code - Requires admin role
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(CreateDiscountResult), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<CreateDiscountResult>> CreateDiscount(
        [FromQuery] string code,
        [FromQuery] decimal amountOff = 0,
        [FromQuery] decimal percentOff = 0,
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null,
        [FromQuery] int maxUses = 0)
    {
        var request = new CreateDiscountRequest(
            Guid.NewGuid(),
            code,
            amountOff,
            percentOff,
            startDate ?? DateTime.UtcNow,
            endDate ?? DateTime.UtcNow.AddYears(1),
            maxUses);

        var result = await _mediator.Send(request);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return CreatedAtAction(nameof(CreateDiscount), new { id = result.DiscountId }, result);
    }
}
