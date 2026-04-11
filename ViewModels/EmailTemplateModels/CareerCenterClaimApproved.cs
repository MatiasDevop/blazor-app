namespace ViewModels.EmailTemplateModels;

public class CareerCenterClaimApproved : ITemplateValues
{
    public string RecipientEmail { get; init; }
    public string Amount { get; init; }
    public string CcName { get; init; }
    public string StartDate { get; init; }
    public string ExpireDate { get; init; }
    public string ProfileUrl { get; init; }
    public string InvoicePaid { get; init; }

    public IEnumerable<string> RecipientEmails { get; set; }

    public IEnumerable<string> Bccs { get; set; }

    public IEnumerable<string> Ccs { get; set; }
}