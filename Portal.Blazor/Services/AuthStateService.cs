using System;
using System.Reactive.Subjects;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Constants;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;

namespace Portal.Blazor.Services
{
    public class AuthStateService
    {
        private readonly AuthenticationStateProvider _provider;
        private readonly UserProfileService _userProfileService;
        private readonly ILogger<AuthStateService> _logger;
        private readonly BehaviorSubject<bool> _authenticated = new(false);

        public IObservable<bool> Authenticated => _authenticated;
        
        public AuthStateService(AuthenticationStateProvider provider, UserProfileService userProfileService, ILogger<AuthStateService> logger)
        {
            _provider = provider;
            _userProfileService = userProfileService;
            _logger = logger;
            _provider.AuthenticationStateChanged += UpdateState;
        }

        public void Init() => UpdateState(_provider.GetAuthenticationStateAsync());
        private async void UpdateState(Task<AuthenticationState> state)
        {
            var stateResult = await state;
            _logger.LogInformation(JsonSerializer.Serialize(stateResult, new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve
            }));
            var isAuthenticated = stateResult.User.Identity?.IsAuthenticated ?? false;
            _authenticated.OnNext(isAuthenticated);
            
            _logger.LogWarning($"Login State Has Changed: {isAuthenticated}");

            if (!isAuthenticated) return;
            var profileImage = stateResult.User.FindFirst(c => c.Type == AppechClaimTypes.Picture)?.Value;
            var exists = await _userProfileService.TryGetProfile();
            if (exists)
                await _userProfileService.GetProfileImage(profileImage);
        }
    }
}
