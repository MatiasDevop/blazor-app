
using Portal.Blazor.Rcl.Permissions.Enums;

namespace Portal.Rcl.Permissions.Models;

public class OrgSelectionItem
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public OrgType? Type { get; set; }
}
