using System;
using ViewModels.Base;

namespace ViewModels.Requests.DataAccess.UserProfile;

public class UserIsClaimHolderForOrgResult : BaseResult
{
    public bool IsClaimHolder { get; }

    public UserIsClaimHolderForOrgResult(Guid requestId, bool isClaimHolder)
    {
        IsClaimHolder = isClaimHolder;
        RequestId = requestId;
    }
}