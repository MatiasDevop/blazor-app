using MediatR;
using ViewModels.Base;
using ViewModels.ViewModels;

namespace ViewModels.Requests.Endpoints.UserProfile;

public class GetEmployeesRequest : BaseRequest, IRequest<GetEmployeesResult>
{
    public int Count { get; }

    public GetEmployeesRequest(Guid requestId, int count)
    {
        RequestId = requestId;
        Count = count;
    }
}

public class GetEmployeesResult : BaseResult
{
    public IEnumerable<UserLabelVm> Employees { get; }

    public GetEmployeesResult(Guid requestId, IEnumerable<UserLabelVm> employees)
    {
        RequestId = requestId;
        Employees = employees;
    }
}
