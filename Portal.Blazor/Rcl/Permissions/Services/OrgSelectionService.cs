using Enums;
using Microsoft.AspNetCore.Components.Authorization;
using Portal.Blazor.Rcl.Permissions.Enums;
using Portal.Blazor.Services;
using Portal.Rcl.Permissions.Models;
using System.Net.Http.Json;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Security.Claims;
using System.Text.Json;
using ViewModels.Dtos;
using ViewModels.Requests.Endpoints.UserProfile;

namespace Portal.Rcl.Permissions.Services;

public class OrgSelectionService : IOrgSelectionService
{
    private readonly ILogger<OrgSelectionService> _logger;
    private readonly AuthenticationStateProvider _authProvider;
    private readonly HttpClient? _httpClient;

    private static readonly BehaviorSubject<Guid> _currentOrgId = new(Guid.Empty);
    private static readonly BehaviorSubject<List<CompanyClaimDto>> _companies = new(new());
    private static readonly BehaviorSubject<List<SchoolClaimDto>> _schools = new(new());
    private static readonly BehaviorSubject<OrgType?> _currentOrgType = new(null);

    private static readonly BehaviorSubject<Dictionary<OrgUserRoleType, bool>> _roleStatuses =
        new(new Dictionary<OrgUserRoleType, bool>());

    public IObservable<Dictionary<OrgUserRoleType, bool>> RoleStatuses => _roleStatuses;
    public IObservable<Guid> CurrentOrgId => _currentOrgId;
    public IObservable<List<CompanyClaimDto>> AvailableCompanies => _companies;
    public IObservable<List<SchoolClaimDto>> AvailableSchools => _schools;

    private static readonly BehaviorSubject<OrgSelectionItem?> _currentOrg = new(null);
    public IObservable<OrgSelectionItem?> CurrentOrg => _currentOrg;
    public IObservable<OrgType?> CurrentOrgType => _currentOrgType;


    public HttpClient? GetOrgHttpClient()
    {
        _logger.LogInformation($"[GetOrgHttpClient] - Retrieving Org Enabled Http Client");

        _logger.LogInformation($"[GetOrgHttpClient] - Getting Selected Org from Service");
        var selectedOrg = _currentOrgId.Value;

        if (selectedOrg == Guid.Empty)
        {
            _logger.LogInformation($"[GetOrgHttpClient] - Org not selected.  Returning null");
            return null;
        }

        _logger.LogInformation($"[GetOrgHttpClient] - Current Org Set to: {selectedOrg.ToString()}");
        _logger.LogInformation($"[GetOrgHttpClient] - Adding to Headers for Client");

        _logger.LogInformation(
            $"[GetOrgHttpClient] - Either the value in headers was wrong, or multiple vales where detected");
        _logger.LogInformation($"[GetOrgHttpClient] - Clearing Headers and adding single value.");
        _httpClient.DefaultRequestHeaders.Remove("org-id");
        _httpClient.DefaultRequestHeaders.Add("org-id", selectedOrg.ToString());

        _logger.LogInformation($"[GetOrgHttpClient] - Sending Client to calling method");

        return _httpClient;
    }

    public async void LoadRoles()
    {
        try
        {
        _logger.LogInformation($"[LoadRoles] - Loading All Roles in a Single Call");

        var user = (await _authProvider.GetAuthenticationStateAsync()).User;

        _logger.LogInformation($"[LoadRoles] - Current User = {user.Identities.First().Name}");

        var roleClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
        if (string.IsNullOrEmpty(roleClaim))
        {
            _logger.LogInformation($"[LoadRoles] - No role claims found. Skipping role loading.");
            return;
        }

        var roles = JsonSerializer.Deserialize<string[]>(roleClaim);

        foreach (var role in roles)
        {
            _logger.LogInformation($"[LoadRoles] - Role = {role}");
        }

        var currentOrg = _currentOrgId.Value.ToString();
        _logger.LogInformation($"[LoadRoles] - CurrentOrg = {currentOrg}");

        var roleStatuses = new Dictionary<OrgUserRoleType, bool>();

        roleStatuses.Add(OrgUserRoleType.UserManager, roles.Any(r =>
            r == $"{currentOrg}::user_manager" || r == $"{currentOrg}::account_owner" ||
            r == $"{currentOrg}::claim_holder"));
        roleStatuses.Add(OrgUserRoleType.JobsManager, roles.Any(r =>
            r == $"{currentOrg}::job_manager" || r == $"{currentOrg}::account_owner" ||
            r == $"{currentOrg}::claim_holder"));
        roleStatuses.Add(OrgUserRoleType.EventsManager, roles.Any(r =>
            r == $"{currentOrg}::events_manager" || r == $"{currentOrg}::account_owner" ||
            r == $"{currentOrg}::claim_holder"));
        roleStatuses.Add(OrgUserRoleType.Accounting, roles.Any(r =>
            r == $"{currentOrg}::accounting" || r == $"{currentOrg}::account_owner" ||
            r == $"{currentOrg}::claim_holder"));
        roleStatuses.Add(OrgUserRoleType.BillingContact,
            roles.Any(r =>
                r == $"{currentOrg}::billing" || r == $"{currentOrg}::account_owner" ||
                r == $"{currentOrg}::claim_holder"));
        roleStatuses.Add(OrgUserRoleType.TechnicalContact, roles.Any(r => r == $"{currentOrg}::technical"));
        roleStatuses.Add(OrgUserRoleType.AccountOwner,
            roles.Any(r => r == $"{currentOrg}::account_owner" || r == $"{currentOrg}::claim_holder"));
        roleStatuses.Add(OrgUserRoleType.DisplayProfile, roles.Any(r => r == $"{currentOrg}::display_profile"));
        roleStatuses.Add(OrgUserRoleType.IsRecruiter,
            roles.Any(r =>
                r == $"{currentOrg}::recruiter" || r == $"{currentOrg}::account_owner" ||
                r == $"{currentOrg}::claim_holder"));


        _logger.LogInformation($"[LoadRoles] - Role Dictionary = {JsonSerializer.Serialize(roleStatuses)}");

        _roleStatuses.OnNext(roleStatuses);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "[LoadRoles] - Failed to load roles. Continuing without role data.");
        }
    }

    private OrgType? GetCurrentOrgType(Guid id)
    {
        _logger.LogInformation($"[GetCurrentOrgType] - Setting Org Type");
        if (_companies.Value.Any(c => c.Id == id)) return OrgType.Company;
        if (_schools.Value.Any(c => c.Id == id)) return OrgType.CareerCenter;

        _logger.LogInformation($"[GetCurrentOrgType] - Org Type not Found");
        return null;
    }

    public OrgSelectionService(IHttpClientFactory httpClientFactory, ILogger<OrgSelectionService> logger,
        AuthenticationStateProvider authProvider)
    {
        _logger = logger;
        _logger.LogInformation($"[constructor] - Constructing OrgSelectionService Service");

        _authProvider = authProvider;

        _httpClient = httpClientFactory.CreateClient(DefaultHttpClients.Secured);

        _logger.LogInformation($"[constructor] - Loading Available Orgs");
        LoadAvailableOrgs();
        _logger.LogInformation($"[constructor] - Constructing OrgSelectionService Complete");
    }

    public void SelectOrg(Guid orgId)
    {
        _logger.LogInformation($"[SelectOrg] - Selecting Org: {orgId}");
        _currentOrgId.OnNext(orgId);
        _logger.LogInformation($"[SelectOrg] - Selecting OrgTyp");
        var orgType = GetCurrentOrgType(orgId);
        _logger.LogInformation($"[SelectOrg] - Setting OrgType to {orgType}");
        var orgName = GetOrgName(orgId, orgType);
        _currentOrgType.OnNext(orgType);
        _currentOrg.OnNext(new OrgSelectionItem() { Id = orgId, Type = orgType, Name = orgName });
        _logger.LogInformation($"[SelectOrg] - Org Type and Id Set");
    }

    private string GetOrgName(Guid orgId, OrgType? orgType)
    {
        _logger.LogInformation($"[GetOrgName] - Getting orgName for Id: {orgId}");
        string orgName = "unknown";
        if (orgType != null)
        {
            switch (orgType)
            {
                case OrgType.CareerCenter:
                    orgName = _schools.Value.First(x => x.Id == orgId).CareerCenterName;
                    _logger.LogInformation($"[GetOrgName] - Career Center Name Found");
                    break;
                case OrgType.Company:
                    orgName = _companies.Value.First(x => x.Id == orgId).Company.Name;
                    _logger.LogInformation($"[GetOrgName] - Company Name Found");
                    break;
                case null:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        _logger.LogInformation($"[GetOrgName] - Sending back orgName: {orgName}");
        return orgName;
    }

    public async void LoadAvailableOrgs()
    {
        try
        {
            _logger.LogInformation($"[LoadAvailableOrgs] - Loading Available Orgs");
            var response =
                await _httpClient.GetFromJsonAsync<GetCompaniesForUserProfileResult>($"UserProfile/AssignedOrgs");
            if (response != null)
            {
                _logger.LogInformation($"[LoadAvailableOrgs] - Setting Values from Response");
                _companies.OnNext(response.Companies.ToList());

                _schools.OnNext(response.Schools.ToList());

                if (response.Companies.ToList().Count > 0)
                {
                    _logger.LogInformation($"[LoadAvailableOrgs] - Setting Company");
                    SelectOrg(response.Companies.First().Id);
                }

                if (response.Schools.ToList().Count > 0)
                {
                    _logger.LogInformation($"[LoadAvailableOrgs] - Setting Career Center");
                    SelectOrg(response.Schools.First().Id);
                }
            }
            else
            {
                _logger.LogInformation($"[LoadAvailableOrgs] - response was null.");
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "[LoadAvailableOrgs] - Failed to load orgs. Continuing without org data.");
        }
    }
}
