
using MediatR;
using ViewModels.Base;


namespace ViewModels.Requests.DataAccess.UserProfile;

public class GetAllUsersPagedRequest : BaseRequest, IRequest<GetAllUsersPagedResult>
{
    public int Page { get; set; }
    public int Size { get; }
    public string SortProperty { get; }
    public bool SortAscending { get; }

    public GetAllUsersPagedRequest(Guid requestId, int page, int size, string sortProperty, bool sortAscending = false)
    {
        Page = page;
        Size = size;
        SortProperty = sortProperty;
        SortAscending = sortAscending;
        RequestId = requestId;
    }
}