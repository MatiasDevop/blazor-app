using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using Domain.Entities;
using ViewModels.Requests.Endpoints.Discounts;

namespace Portal.Api.Handlers.Discounts;

public class CreateDiscountHandler : IRequestHandler<CreateDiscountRequest, CreateDiscountResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CreateDiscountHandler> _logger;

    public CreateDiscountHandler(ApplicationDbContext context, ILogger<CreateDiscountHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<CreateDiscountResult> Handle(CreateDiscountRequest request, CancellationToken cancellationToken)
    {
        // Check if discount code already exists
        var existingDiscount = await _context.Discounts
            .FirstOrDefaultAsync(d => d.Code == request.Code, cancellationToken);

        if (existingDiscount != null)
        {
            _logger.LogWarning("Discount code {Code} already exists", request.Code);
            return new CreateDiscountResult(
                request.RequestId,
                false,
                $"Discount code '{request.Code}' already exists");
        }

        // Validate that either amount or percentage is set (not both)
        if (request.AmountOff > 0 && request.PercentOff > 0)
        {
            return new CreateDiscountResult(
                request.RequestId,
                false,
                "Cannot set both amount and percentage discounts");
        }

        if (request.AmountOff == 0 && request.PercentOff == 0)
        {
            return new CreateDiscountResult(
                request.RequestId,
                false,
                "Must specify either amount or percentage discount");
        }

        // Create discount
        var discount = new Discount
        {
            Id = Guid.NewGuid(),
            Code = request.Code.ToUpper(),
            Amount = request.AmountOff > 0 ? request.AmountOff : request.PercentOff,
            IsPercentage = request.PercentOff > 0,
            ExpiresAt = request.EndDate
        };

        _context.Discounts.Add(discount);
        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Discount created: {DiscountId} with code {Code}",
            discount.Id, discount.Code);

        return new CreateDiscountResult(
            request.RequestId,
            true,
            "Discount code created successfully",
            discount.Id);
    }
}
