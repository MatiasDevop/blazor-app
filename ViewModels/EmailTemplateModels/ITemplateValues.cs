namespace ViewModels.EmailTemplateModels;

public interface ITemplateValues
{
    string RecipientEmail { get; }
    IEnumerable<string> RecipientEmails { get; set; }
    IEnumerable<string> Bccs { get; set; }
    IEnumerable<string> Ccs { get; set; }
}
