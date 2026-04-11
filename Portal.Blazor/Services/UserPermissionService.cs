using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reactive.Subjects;
using Portal.Rcl.Permissions.Services;
using ViewModels.Dtos;
using ViewModels.Requests.Endpoints.UserProfile;

namespace Portal.Blazor.Services;

public class UserPermissionService
{
    private readonly IOrgSelectionService _orgSelectionService;
    private readonly BehaviorSubject<List<OrgUserConnectionDto>> _orgUserConnections = new(null);
    private readonly BehaviorSubject<bool> _isClaimHolder = new(false);
    public IObservable<List<OrgUserConnectionDto>> OrgUserConnections => _orgUserConnections;
    public IObservable<bool> IsClaimHolder => _isClaimHolder;
    public UserPermissionService(IOrgSelectionService orgSelectionService)
    {
        _orgSelectionService = orgSelectionService;
    }
    
    public async void GetPermissions()
    {
        var client = _orgSelectionService.GetOrgHttpClient();
        if (client != null)
        {
            var permissions =
                await client.GetFromJsonAsync<GetPermissionsForCurrentOrgResult>("UserProfile/permissions");
            _isClaimHolder.OnNext(permissions.IsClaimHolder);
            _orgUserConnections.OnNext(permissions.Permissions?.ToList());
        }
    }
}
