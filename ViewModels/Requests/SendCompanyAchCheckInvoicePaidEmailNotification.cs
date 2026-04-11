using MediatR;
using ViewModels.Base;

namespace ViewModels.Requests;

public class SendCompanyAchCheckInvoicePaidEmailNotification : BaseRequest, INotification
{
    public SendCompanyAchCheckInvoicePaidEmailNotification(Guid requestId, string subject, string senderEmail, string recipientEmail,
        decimal amount, bool approved, DateTime startDate, DateTime expireDate, string profileUrl, string alaCarteUrl,
        string companyName, string partnerPlan)
    {
        RequestId = requestId;
        Subject = subject;
        SenderEmail = senderEmail;
        RecipientEmail = recipientEmail;
        Amount = amount;
        Approved = approved;
        StartDate = startDate;
        ExpireDate = expireDate;
        ProfileUrl = profileUrl;
        AlaCarteUrl = alaCarteUrl;
        CompanyName = companyName;
        PartnerPlan = partnerPlan;
    }

    public string Subject { get; }
    public string SenderEmail { get; }
    public string RecipientEmail { get; }
    public decimal Amount { get; }
    public bool Approved { get; }
    public DateTime StartDate { get; }
    public DateTime ExpireDate { get; }
    public string ProfileUrl { get; }
    public string AlaCarteUrl { get; }
    public string CompanyName { get; }
    public string PartnerPlan { get; }
}
