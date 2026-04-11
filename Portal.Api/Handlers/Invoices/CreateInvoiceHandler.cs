using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using Domain.Entities;
using ViewModels.Requests.Endpoints.Invoices;

namespace Portal.Api.Handlers.Invoices;

public class CreateInvoiceHandler : IRequestHandler<CreateInvoiceRequest, CreateInvoiceResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CreateInvoiceHandler> _logger;

    public CreateInvoiceHandler(ApplicationDbContext context, ILogger<CreateInvoiceHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<CreateInvoiceResult> Handle(CreateInvoiceRequest request, CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            // Verify company exists
            var company = await _context.CompanyProfiles
                .FindAsync(new object[] { request.CompanyProfileId }, cancellationToken);

            if (company == null)
            {
                _logger.LogWarning("Company {CompanyId} not found", request.CompanyProfileId);
                throw new KeyNotFoundException($"Company with ID {request.CompanyProfileId} not found");
            }

            // Calculate total
            decimal subtotal = request.Items.Sum(item => item.Amount * item.Quantity);
            decimal discountAmount = 0;

            // Apply discount if provided
            if (request.DiscountId.HasValue)
            {
                var discount = await _context.Discounts
                    .FirstOrDefaultAsync(d => d.Id == request.DiscountId.Value, cancellationToken);

                if (discount != null)
                {
                    // Check if discount is expired
                    if (discount.ExpiresAt.HasValue && discount.ExpiresAt.Value < DateTime.UtcNow)
                    {
                        _logger.LogWarning("Discount {DiscountId} is expired", discount.Id);
                    }
                    else
                    {
                        discountAmount = discount.IsPercentage
                            ? subtotal * (discount.Amount / 100)
                            : discount.Amount;

                        _logger.LogInformation("Applied discount {Code}: {Amount}",
                            discount.Code, discountAmount);
                    }
                }
            }

            decimal total = subtotal - discountAmount;

            // Create invoice header
            var invoiceHeader = new InvoiceHeader
            {
                Id = Guid.NewGuid(),
                CompanyProfileId = request.CompanyProfileId,
                CreatedAt = DateTime.UtcNow
            };

            _context.InvoiceHeaders.Add(invoiceHeader);

            // Create invoice details
            foreach (var item in request.Items)
            {
                var detail = new InvoiceDetail
                {
                    Id = Guid.NewGuid(),
                    InvoiceHeaderId = invoiceHeader.Id,
                    Description = item.Description,
                    Amount = item.Amount * item.Quantity
                };

                _context.InvoiceDetails.Add(detail);
            }

            // Add discount as a negative line item if applied
            if (discountAmount > 0)
            {
                var discountDetail = new InvoiceDetail
                {
                    Id = Guid.NewGuid(),
                    InvoiceHeaderId = invoiceHeader.Id,
                    Description = "Discount Applied",
                    Amount = -discountAmount
                };

                _context.InvoiceDetails.Add(discountDetail);
            }

            await _context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            _logger.LogInformation("Invoice created: {InvoiceId} for company {CompanyId} with total {Total}",
                invoiceHeader.Id, request.CompanyProfileId, total);

            return new CreateInvoiceResult(
                request.RequestId,
                true,
                "Invoice created successfully",
                invoiceHeader.Id,
                total);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            _logger.LogError(ex, "Error creating invoice for company {CompanyId}", request.CompanyProfileId);
            throw;
        }
    }
}
