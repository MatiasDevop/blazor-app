using MediatR;
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.Endpoints.Discounts;

public class CreateDiscountRequest : BaseRequest, IRequest<CreateDiscountResult>
{
    public string Code { get; }
    public decimal AmountOff { get; }
    public decimal PercentOff { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public int MaxUses { get; }

    public CreateDiscountRequest(
        Guid requestId,
        string code,
        decimal amountOff,
        decimal percentOff,
        DateTime startDate,
        DateTime endDate,
        int maxUses)
    {
        RequestId = requestId;
        Code = code;
        AmountOff = amountOff;
        PercentOff = percentOff;
        StartDate = startDate;
        EndDate = endDate;
        MaxUses = maxUses;
    }
}

public class CreateDiscountResult : BaseResult
{
    public bool Success { get; }
    public string Message { get; }
    public Guid? DiscountId { get; }

    public CreateDiscountResult(Guid requestId, bool success, string message, Guid? discountId = null)
    {
        RequestId = requestId;
        Success = success;
        Message = message;
        DiscountId = discountId;
    }
}
