using System;

namespace ViewModels.ViewModels;

public class UserOrgRolesContainer
{
    public Guid OrgId { get; set; }
    public bool IsAccounting { get; set; }
    public bool IsBilling { get; set; }
    public bool IsClaimHolder { get; set; }
    public bool IsEventsManager { get; set; }
    public bool IsUserManager { get; set; }
    public bool IsRecruiter { get; set; }
    public bool IsTechnical { get; set; }
    public bool IsAccountOwner { get; set; }
    public bool IsJobManager { get; set; }
}