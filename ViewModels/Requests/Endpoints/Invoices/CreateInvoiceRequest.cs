using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.Endpoints.Invoices;

public class CreateInvoiceRequest : BaseRequest, IRequest<CreateInvoiceResult>
{
    public Guid CompanyProfileId { get; }
    public List<InvoiceItemDto> Items { get; }
    public Guid? DiscountId { get; }

    public CreateInvoiceRequest(
        Guid requestId,
        Guid companyProfileId,
        List<InvoiceItemDto> items,
        Guid? discountId = null)
    {
        RequestId = requestId;
        CompanyProfileId = companyProfileId;
        Items = items;
        DiscountId = discountId;
    }
}

public class CreateInvoiceResult : BaseResult
{
    public bool Success { get; }
    public string Message { get; }
    public Guid? InvoiceId { get; }
    public decimal TotalAmount { get; }

    public CreateInvoiceResult(
        Guid requestId,
        bool success,
        string message,
        Guid? invoiceId = null,
        decimal totalAmount = 0)
    {
        RequestId = requestId;
        Success = success;
        Message = message;
        InvoiceId = invoiceId;
        TotalAmount = totalAmount;
    }
}

public class InvoiceItemDto
{
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public int Quantity { get; set; } = 1;
}
