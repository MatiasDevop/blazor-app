using System;
using MediatR;
using ViewModels.Base;

namespace ViewModels.Requests;

public class SendCareerCenterAchCheckInvoicePaidEmailNotification : BaseRequest, INotification
{
    public SendCareerCenterAchCheckInvoicePaidEmailNotification(Guid requestId, string subject, string senderEmail, string recipientEmail, decimal amount, string careerCenterName, bool approved, DateTime startDate, DateTime expireDate, string profileUrl)
    {
        RequestId = requestId;
        Subject = subject;
        SenderEmail = senderEmail;
        RecipientEmail = recipientEmail;
        Amount = amount;
        CareerCenterName = careerCenterName;
        Approved = approved;
        StartDate = startDate;
        ExpireDate = expireDate;
        ProfileUrl = profileUrl;
    }

    public string Subject { get; }
    public string SenderEmail { get; }
    public string RecipientEmail { get; }
    public decimal Amount { get; }
    public string CareerCenterName { get; }
    public bool Approved { get; }
    public DateTime StartDate { get; }
    public DateTime ExpireDate { get; }
    public string ProfileUrl { get; }
}