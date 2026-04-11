using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using ViewModels.Dtos;

namespace Portal.Blazor.Services
{
    public class UserConnectionService
    {
        private readonly UserProfileService _userProfileService;
        private readonly ToastService _toastService;
        private readonly LoadingService _loadingService;
        private HttpClient _httpClient;
        private BehaviorSubject<List<UserConnectionDto>> _pendingConnections = new(new());

        public IObservable<List<UserConnectionDto>> PendingConnections => _pendingConnections;
        
        public UserConnectionService(IHttpClientFactory httpClientFactory, UserProfileService userProfileService, ToastService toastService, LoadingService loadingService)
        {
            _userProfileService = userProfileService;
            _toastService = toastService;
            _loadingService = loadingService;
            _httpClient = httpClientFactory.CreateClient(DefaultHttpClients.Secured);
        }

        public async void ApproveConnection(Guid id)
        {
            try
            {
                _loadingService.Show();
                await _httpClient.PatchAsync($"UserConnection/{id}/Accept", null);
                await _userProfileService.TryGetProfile();
                var pendingConnection = _pendingConnections.Value.FirstOrDefault(x => x.Id == id);
                _pendingConnections.Value.Remove(pendingConnection);
                _pendingConnections.OnNext(_pendingConnections.Value);
            }
            catch (Exception e)
            {
                _toastService.ShowToast(e.Message, ToastLevel.Error, "Unknown Error");
            }
            finally
            {
                _loadingService.Hide();
            }
        }
        public async void DeclineConnection(Guid id)
        {
            try
            {
                await _httpClient.PatchAsync($"UserConnection/{id}/Decline", null);
                await _userProfileService.TryGetProfile();
                var pendingConnection = _pendingConnections.Value.FirstOrDefault(x => x.Id == id);
                _pendingConnections.Value.Remove(pendingConnection);
                _pendingConnections.OnNext(_pendingConnections.Value);
            }
            catch (Exception e)
            {
                _toastService.ShowToast(e.Message, ToastLevel.Error, "Unknown Error");
            }
            finally
            {
                _loadingService.Hide();
            }
        }
        
        public async void DeleteConnection(Guid id)
        {
            try
            {
                await _httpClient.DeleteAsync($"UserConnection/{id}");
                await _userProfileService.TryGetProfile();
            }
            catch (Exception e)
            {
                _toastService.ShowToast(e.Message, ToastLevel.Error, "Unknown Error");
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async void GetPendingConnections()
        {
            try
            {
                var connections = await _httpClient.GetFromJsonAsync<List<UserConnectionDto>>("UserConnection/Pending");
                _pendingConnections.OnNext(connections);
            }
            catch (Exception e)
            {
                _toastService.ShowToast(e.Message, ToastLevel.Error, "Unknown Error");
            }
        }
        
        public async Task MakeConnection(UserConnectionDto dto)
        {
            try
            {
                _loadingService.Show();
                await _httpClient.PostAsJsonAsync("UserConnection", dto);
                await _userProfileService.TryGetProfile();
            }
            finally
            {
                _loadingService.Hide();
            }
        }
    }
}

