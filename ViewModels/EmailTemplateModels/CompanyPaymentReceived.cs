namespace ViewModels.EmailTemplateModels;

public class CompanyPaymentReceived : ITemplateValues
{
    public string RecipientEmail { get; init; }
    public string Amount { get; init; }
    public string Approved { get; init; }
    public string CompanyName { get; init; }
    public string StartDate { get; init; }
    public string ExpireDate { get; init; }
    public string ProfileUrl { get; init; }
    public string AlaCarteUrl { get; init; }
    public string PartnerPlan { get; init; }

    public IEnumerable<string> RecipientEmails { get; set; }

    public IEnumerable<string> Bccs { get; set; }

    public IEnumerable<string> Ccs { get; set; }
}