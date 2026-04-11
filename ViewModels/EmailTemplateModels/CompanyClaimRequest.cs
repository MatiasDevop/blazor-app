namespace ViewModels.EmailTemplateModels;

public class CompanyClaimRequest : ITemplateValues
{
    public string RecipientEmail { get; init; }
    public string CompanyName { get; init; }
    public string ProfileUrl { get; init; }

    public IEnumerable<string> RecipientEmails { get; set; }

    public IEnumerable<string> Bccs { get; set; }

    public IEnumerable<string> Ccs { get; set; }
}