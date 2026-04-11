
using MediatR;
using ViewModels.Base;

namespace ViewModels.Requests;

public class SendCompanyClaimApprovedEmailNotification : BaseRequest, INotification
{
    public SendCompanyClaimApprovedEmailNotification(Guid requestId, string subject, string senderEmail, string recipientEmail, decimal amount, DateTime startDate, DateTime expireDate, string profileUrl, string alaCarteUrl, string companyName, bool invoicePaid, string partnerPlan)
    {
        RequestId = requestId;
        Subject = subject;
        SenderEmail = senderEmail;
        RecipientEmail = recipientEmail;
        Amount = amount;
        StartDate = startDate;
        ExpireDate = expireDate;
        ProfileUrl = profileUrl;
        AlaCarteUrl = alaCarteUrl;
        CompanyName = companyName;
        InvoicePaid = invoicePaid;
        PartnerPlan = partnerPlan;
    }

    public string Subject { get; }
    public string SenderEmail { get; }
    public string RecipientEmail { get; }
    public decimal Amount { get; }
    public DateTime StartDate { get; }
    public DateTime ExpireDate { get; }
    public string ProfileUrl { get; }
    public string AlaCarteUrl { get; }
    public string CompanyName { get; }
    public bool InvoicePaid { get; }
    public string PartnerPlan { get; }
}