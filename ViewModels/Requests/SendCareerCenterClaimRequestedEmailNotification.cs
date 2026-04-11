using System;
using MediatR;
using ViewModels.Base;

namespace ViewModels.Requests;

public class SendCareerCenterClaimRequestedEmailNotification : BaseRequest, INotification
{
    public SendCareerCenterClaimRequestedEmailNotification(Guid requestId, string subject, string senderEmail, string recipientEmail, string careerCenterName, string profileUrl)
    {
        RequestId = requestId;
        Subject = subject;
        SenderEmail = senderEmail;
        RecipientEmail = recipientEmail;
        CareerCenterName = careerCenterName;
        ProfileUrl = profileUrl;
    }

    public string Subject { get; }
    public string SenderEmail { get; }
    public string RecipientEmail { get; }
    public string CareerCenterName { get; }
    public string ProfileUrl { get; }
}
