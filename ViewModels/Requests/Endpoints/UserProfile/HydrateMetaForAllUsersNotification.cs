using MediatR;
using ViewModels.Base;



namespace ViewModels.Requests.Endpoints.UserProfile;

public class HydrateMetaForAllUsersNotification : BaseRequest, INotification
{
    public HydrateMetaForAllUsersNotification(Guid requestId)
    {
        RequestId = requestId;
    }
}


