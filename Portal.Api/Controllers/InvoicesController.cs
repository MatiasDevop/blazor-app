using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Requests.Endpoints.Invoices;

namespace Portal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class InvoicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public InvoicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Create a new invoice for a company - Requires authentication
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(CreateInvoiceResult), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CreateInvoiceResult>> CreateInvoice([FromBody] CreateInvoiceRequest request)
    {
        var result = await _mediator.Send(request);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return CreatedAtAction(nameof(CreateInvoice), new { id = result.InvoiceId }, result);
    }
}
