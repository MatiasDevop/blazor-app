using System;
using MediatR;
using ViewModels.Base;

namespace ViewModels.Requests;

public class SendCompanyClaimRequestedEmailNotification : BaseRequest, INotification
{
    public SendCompanyClaimRequestedEmailNotification(Guid requestId, string subject, string senderEmail, string recipientEmail, string companyName,
        string profileUrl)
    {
        RequestId = requestId;
        Subject = subject;
        SenderEmail = senderEmail;
        RecipientEmail = recipientEmail;
        CompanyName = companyName;
        ProfileUrl = profileUrl;
    }

    public string Subject { get; }
    public string SenderEmail { get; }
    public string RecipientEmail { get; }
    public string CompanyName { get; }
    public string ProfileUrl { get; }
}