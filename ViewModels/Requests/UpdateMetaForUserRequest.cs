using System;
using MediatR;
using ViewModels.Base;


namespace ViewModels.Requests;

public class UpdateMetaForUserRequest : BaseRequest, IRequest<UpdateMetaForUserResult>
{
    public Guid UserId { get; }

    public UpdateMetaForUserRequest(Guid requestId, Guid userId)
    {
        UserId = userId;
        RequestId = requestId;
    }
}