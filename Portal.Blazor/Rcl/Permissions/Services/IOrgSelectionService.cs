using Enums;
using Portal.Blazor.Rcl.Permissions.Enums;
using Portal.Rcl.Permissions.Models;
using ViewModels.Dtos;

namespace Portal.Rcl.Permissions.Services;

public interface IOrgSelectionService
{
    IObservable<Guid> CurrentOrgId { get; }
    void SelectOrg(Guid orgId);
    void LoadAvailableOrgs();
    IObservable<List<CompanyClaimDto>> AvailableCompanies { get; }
    IObservable<List<SchoolClaimDto>> AvailableSchools { get; }
    IObservable<OrgType?> CurrentOrgType { get; }
    IObservable<OrgSelectionItem?> CurrentOrg { get; }
    IObservable<Dictionary<OrgUserRoleType, bool>> RoleStatuses { get; }
    HttpClient? GetOrgHttpClient();

    void LoadRoles();
}

//public class OrgSelectionService : IOrgSelectionService
//{
//    public OrgSelectionItem? SelectedOrganization { get; private set; }

//    public event Action? OnOrganizationChanged;

//    public async Task<List<OrgSelectionItem>> GetOrganizationsForUserAsync()
//    {
//        // Placeholder implementation
//        await Task.CompletedTask;
//        return new List<OrgSelectionItem>();
//    }

//    public void SelectOrganization(OrgSelectionItem organization)
//    {
//        SelectedOrganization = organization;
//        OnOrganizationChanged?.Invoke();
//    }
//}

