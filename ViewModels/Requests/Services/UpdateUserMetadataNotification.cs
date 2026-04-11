using MediatR;
using ViewModels.Base;


namespace ViewModels.Requests.Services;

public class UpdateUserMetadataNotification : BaseRequest, INotification
{
    public string Email { get; }

    public UpdateUserMetadataNotification(Guid requestId, string email)
    {
        Email = email;
        RequestId = requestId;
    }
}


