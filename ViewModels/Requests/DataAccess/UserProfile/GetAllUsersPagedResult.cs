
using ViewModels.Base;
using ViewModels.Dtos;

namespace ViewModels.Requests.DataAccess.UserProfile;

public class GetAllUsersPagedResult : BaseResult
{
    public int Page { get; }
    public int Size { get; }
    public string SortProperty { get; }
    public bool SortAscending { get; }
    public int Count { get; }
    public IEnumerable<FullUserProfileDto> Payload { get; }

    public GetAllUsersPagedResult(Guid requestId, int page, int size, string sortProperty, bool sortAscending, int count, IEnumerable<FullUserProfileDto> payload)
    {
        Page = page;
        Size = size;
        SortProperty = sortProperty;
        SortAscending = sortAscending;
        Count = count;
        Payload = payload;
        RequestId = requestId;
    }
}