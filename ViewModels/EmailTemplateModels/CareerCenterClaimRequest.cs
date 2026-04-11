//using Appech.MediatR.Email.TransferObjects;

namespace ViewModels.EmailTemplateModels;

public class CareerCenterClaimRequest : ITemplateValues
{
    public string RecipientEmail { get; init; }
    public string CcName { get; init; }
    public string ProfileUrl { get; init; }

    public IEnumerable<string> RecipientEmails { get; set; }

    public IEnumerable<string> Bccs { get; set; }

    public IEnumerable<string> Ccs { get; set; }
}