using System;
using MediatR;
using ViewModels.Base;

namespace ViewModels.Requests;

public class SendCareerCenterClaimApprovedEmailNotification : BaseRequest, INotification
{
    public SendCareerCenterClaimApprovedEmailNotification(Guid requestId, string subject, string senderEmail, string recipientEmail,
        decimal amount, string careerCenterName, DateTime startDate, DateTime expireDate, string profileUrl,
        bool invoicePaid)
    {
        RequestId = requestId;
        Subject = subject;
        SenderEmail = senderEmail;
        RecipientEmail = recipientEmail;
        Amount = amount;
        CareerCenterName = careerCenterName;
        StartDate = startDate;
        ExpireDate = expireDate;
        ProfileUrl = profileUrl;
        InvoicePaid = invoicePaid;
    }

    public string Subject { get; }
    public string SenderEmail { get; }
    public string RecipientEmail { get; }
    public decimal Amount { get; }
    public string CareerCenterName { get; }
    public DateTime StartDate { get; }
    public DateTime ExpireDate { get; }
    public string ProfileUrl { get; }
    public bool InvoicePaid { get; }
}