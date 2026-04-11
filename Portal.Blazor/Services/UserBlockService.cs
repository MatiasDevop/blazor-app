using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Constants;
using ViewModels.Commands;

namespace Portal.Blazor.Services;

public class UserBlockService
{
    private readonly ToastService _toastService;
    private readonly UserProfileService _userProfileService;
    private readonly LoadingService _loadingService;
    private readonly WeavyService _weavyService;
    private readonly HttpClient _httpClient;
    private readonly Dictionary<Guid, BehaviorSubject<bool?>> _blocks = new();

    public UserBlockService(IHttpClientFactory httpClientFactory, ToastService toastService, UserProfileService userProfileService, LoadingService loadingService, WeavyService weavyService)
    {
        _toastService = toastService;
        _userProfileService = userProfileService;
        _loadingService = loadingService;
        _weavyService = weavyService;
        _httpClient = httpClientFactory.CreateClient(DefaultHttpClients.Secured);
    }

    public IObservable<bool?> this[Guid id]
    {
        get
        {
            if (_blocks.ContainsKey(id))
                return _blocks[id].Where(x => x != null);
            _blocks[id] = new(null);
            CheckIfBlocked(id);
            return _blocks[id].Where(x => x != null);
        }
    }

    private async void CheckIfBlocked(Guid id)
    {
        var response = await _httpClient.GetAsync($"UserBlock?blocker={id}");
        _blocks[id].OnNext(!response.IsSuccessStatusCode);
    }

    public async void BlockUser(BlockUserCommand command)
    {
        try
        {
            _loadingService.Show();
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("UserBlock", UriKind.Relative),
                Content = JsonContent.Create(command)
            };
            request.Headers.Add(Headers.WeavyAuthorization, _weavyService.AccessToken);
            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException(await response.Content.ReadAsStringAsync(), null, response.StatusCode);
            await _userProfileService.TryGetProfile();
        }
        catch (HttpRequestException e)
        {
            _toastService.ShowToast(e.Message, ToastLevel.Error, "Unknown Error");
        }
        finally
        {
            _loadingService.Hide();
        }
    }

    public async void UnblockUser(Guid userId)
    {
        try
        {
            _loadingService.Show();
            var response = await _httpClient.DeleteAsync($"UserBlock/{userId}");
            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException(await response.Content.ReadAsStringAsync(), null, response.StatusCode);
            await _userProfileService.TryGetProfile();
        }
        catch (HttpRequestException e)
        {
            _toastService.ShowToast(e.Message, ToastLevel.Error, "Unknown Error");
        }
        finally
        {
            _loadingService.Hide();
        }
    }
}

