

using ViewModels.Base;

namespace ViewModels.Requests;

public class UpdateMetaForUserResult : BaseResult
{
    public UpdateMetaForUserResult(Guid requestId)
    {
        RequestId = requestId;
    }
}