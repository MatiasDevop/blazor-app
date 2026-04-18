using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using ViewModels.Commands;
using ViewModels.Dtos;
using ViewModels.Queries;
using ViewModels.ViewModels;

namespace Portal.Blazor.Services
{
    public class UserProfileService
    {
        private readonly NavigationManager _navigationManager;
        private readonly ToastService _toastService;
        private readonly ILogger<UserProfileService> _logger;
        private readonly LoadingService _loadingService;
        private readonly SmartTypesService _smartTypesService;
        private readonly HttpClient _httpClient;
        private readonly HttpClient _authorizedClient;
        private readonly BehaviorSubject<List<UserLabelVm>> _employees = new(new());
        private readonly BehaviorSubject<FullUserProfileDto> _profile = new(null);
        private readonly Dictionary<Guid, BehaviorSubject<PartialUserProfileDto>> _userProfiles = new();
        private readonly Dictionary<Guid, BehaviorSubject<string>> _userProfileImages = new();
        private readonly BehaviorSubject<string> _profileImage = new(null);
        public IObservable<List<UserLabelVm>> Employees => _employees;
        public IObservable<FullUserProfileDto> Profile => _profile.Where(x => x != null);
        public IObservable<string> ProfileImage => _profileImage.Where(x => x != null);

        public IObservable<PartialUserProfileDto> UserProfile(Guid id)
        {
            if (!_userProfiles.ContainsKey(id))
            {
                _userProfiles[id] = new BehaviorSubject<PartialUserProfileDto>(null);
                GetUserProfile(id);
            }
            return _userProfiles[id].Where(x => x is not null);
        }
        public IObservable<string> UserProfileImage(Guid id)
        {
            if (!_userProfileImages.ContainsKey(id))
            {
                _userProfileImages[id] = new BehaviorSubject<string>(null);
                GetUserProfileImage(id);
            }
            return _userProfileImages[id].Where(x => x is not null);
        }

        public IObservable<Dictionary<string, List<UserLabelVm>>> EmployeeDecks =>
            _employees.Select(ConvertToDecks);

        public UserProfileService(IHttpClientFactory httpClientFactory, NavigationManager navigationManager,
            ToastService toastService, ILogger<UserProfileService> logger, LoadingService loadingService, SmartTypesService smartTypesService)
        {
            _navigationManager = navigationManager;
            _toastService = toastService;
            _logger = logger;
            _loadingService = loadingService;
            _smartTypesService = smartTypesService;
            _httpClient = httpClientFactory.CreateClient(DefaultHttpClients.Unsecured);
            _authorizedClient = httpClientFactory.CreateClient(DefaultHttpClients.Secured);
        }

        public async void GetEmployees(int employeesToGet = 4)
        {
            try
            {
                var employees =
                    await _httpClient.GetFromJsonAsync<List<UserLabelVm>>($"UserProfile/Employees/{employeesToGet}");
                _employees.OnNext(employees ?? new List<UserLabelVm>());
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "GetEmployees failed. Using empty list to keep UI stable.");
                _employees.OnNext(new List<UserLabelVm>());
            }
        }

        private static Dictionary<string, List<UserLabelVm>> ConvertToDecks(List<UserLabelVm> employees)
        {
            if (employees == null) return null;

            var result = new Dictionary<string, List<UserLabelVm>>();
            var index = 0;
            foreach (var employee in employees)
            {
                if (result.Count <= index)
                {
                    result.Add(index.ToString(), new List<UserLabelVm>());
                }

                result[index.ToString()].Add(employee);

                if (result[index.ToString()].Count == 4)
                {
                    index++;
                }
            }

            return result;
        }

        public async Task<bool> TryGetProfile()
        {
            try
            {
                _logger.LogWarning("Attempting to retrieve User Profile");
                var profile = await _authorizedClient.GetFromJsonAsync<FullUserProfileDto>("UserProfile");

                _logger.LogWarning($"Profile Set for Session: {JsonSerializer.Serialize(profile)}");
                _profile.OnNext(profile);
                if (!_userProfiles.ContainsKey(profile.Id))
                    _userProfiles[profile.Id] = new(profile);
                else
                    _userProfiles[profile.Id].OnNext(profile);

                return true;
            }
            catch (HttpRequestException e)
            {
                if (e.Message.Contains(((int)HttpStatusCode.Forbidden).ToString())
                    || e.Message.Contains(((int)HttpStatusCode.NotFound).ToString()))
                {
                    _logger.LogError(e, "Unable to retrieve profile");
                    //_navigationManager.NavigateTo("/");
                }
            }

            return false;
        }

        public async Task GetProfileImage(string defaultProfileImage)
        {
            var response = await _authorizedClient.GetAsync("UserProfile/Image");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                _profileImage.OnNext(defaultProfileImage);
                return;
            }

            var contentType = response.Content.Headers.ContentType?.ToString();
            var imageResult = await response.Content.ReadAsByteArrayAsync();
            var imageBase64 = Convert.ToBase64String(imageResult);
            _profileImage.OnNext($"data:{contentType};base64, {imageBase64}");
        }

        public async void GetUserProfile(Guid id)
        {
            try
            {
                _logger.LogWarning("Attempting to retrieve User Profile");
                var profile = await _httpClient.GetFromJsonAsync<PartialUserProfileDto>($"UserProfile/{id}");

                _logger.LogWarning($"Profile Set for Session: {JsonSerializer.Serialize(profile)}");
                _userProfiles[id].OnNext(profile);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Unable to retrieve profile {Id}", id);
            }
        }

        public async void GetUserProfileImage(Guid id)
        {
            var response = await _httpClient.GetAsync($"UserProfile/{id}/Image");
            if (response.StatusCode == HttpStatusCode.NotFound)
                return;

            var contentType = response.Content.Headers.ContentType?.ToString();
            var imageResult = await response.Content.ReadAsByteArrayAsync();
            var imageBase64 = Convert.ToBase64String(imageResult);
            _userProfileImages[id].OnNext($"data:{contentType};base64, {imageBase64}");
        }

        public async void ResetPassword()
        {
            var response = await _authorizedClient.PostAsync("UserProfile/reset-password", null);
            if (response.IsSuccessStatusCode)
                _toastService.ShowToast("Password Reset Email was sent", ToastLevel.Success, "Email Sent");
            else
                _toastService.ShowToast("Password Reset Email failed to send", ToastLevel.Error, "Email Failed");
        }

        public async void UpdateMultiSelection(UpdateMultiSelectionCommand command)
        {
            try
            {
                _loadingService.Show();
                await _authorizedClient.PostAsJsonAsync("UserProfile/MultiSelection", command);
                _smartTypesService.FlushTemporaryCodes();
                await TryGetProfile();
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                    _toastService.ShowToast(e.Message, ToastLevel.Error, "Not Found");
                else
                    _toastService.ShowToast(e.Message, ToastLevel.Error, "Unknown Error");
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async void UpdateEducationHistory(EducationHistoryDto educationHistory)
        {
            try
            {
                _loadingService.Show();
                await _authorizedClient.PostAsJsonAsync("UserProfile/EducationHistory", educationHistory);
                await TryGetProfile();
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

        public async void UpdateWorkHistory(WorkHistoryDto workHistory)
        {
            try
            {
                _loadingService.Show();
                await _authorizedClient.PostAsJsonAsync("UserProfile/WorkHistory", workHistory);
                await TryGetProfile();
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

        public async void UpdateWorkSample(WorkSampleDto workSample)
        {
            try
            {
                _loadingService.Show();
                await _authorizedClient.PostAsJsonAsync("UserProfile/WorkSample", workSample);
                await TryGetProfile();
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

        public async void UpdateResume(AttachmentDto resume)
        {
            try
            {
                _loadingService.Show();
                await _authorizedClient.PostAsJsonAsync("UserProfile/Resume", resume);
                await TryGetProfile();
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

        public async void DeleteEducationHistory(Guid id)
        {
            try
            {
                _loadingService.Show();
                await _authorizedClient.DeleteAsync($"UserProfile/EducationHistory/{id}");
                await TryGetProfile();
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

        public async void DeleteWorkHistory(Guid id)
        {
            try
            {
                _loadingService.Show();
                await _authorizedClient.DeleteAsync($"UserProfile/WorkHistory/{id}");
                await TryGetProfile();
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

        public async void DeleteWorkSample(Guid id)
        {
            try
            {
                _loadingService.Show();
                await _authorizedClient.DeleteAsync($"UserProfile/WorkSample/{id}");
                await TryGetProfile();
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

        public async Task<bool> UpdateProfile(UpdateUserProfileCommand command)
        {
            try
            {
                _loadingService.Show();
                var response = await _authorizedClient.PutAsJsonAsync("UserProfile", command);
                if (!response.IsSuccessStatusCode)
                    throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
                _smartTypesService.FlushTemporaryCodes();
                await TryGetProfile();
            }
            catch (Exception e)
            {
                _toastService.ShowToast(e.Message, ToastLevel.Error, "Unknown Error");
                _loadingService.Hide();
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }

            return true;
        }

        public async void UpdateProfileImage(AttachmentDto attachment)
        {
            try
            {
                _loadingService.Show();
                var response = await _authorizedClient.PutAsJsonAsync("UserProfile/ProfileImage", attachment);
                if (!response.IsSuccessStatusCode)
                    throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
                GetUserProfileImage(_profile.Value.Id);
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

        public async void UpdateLanguages(UpdateLangaugesCommand command)
        {
            try
            {
                _loadingService.Show();
                var response = await _authorizedClient.PutAsJsonAsync("UserProfile/Languages", command);
                if (!response.IsSuccessStatusCode)
                    throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
                _smartTypesService.FlushTemporaryCodes();
                await TryGetProfile();
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

        public async void UpdateSocialLinks(UpdateSocialLinksCommand command)
        {
            try
            {
                _loadingService.Show();
                var response = await _authorizedClient.PutAsJsonAsync("UserProfile/SocialLinks", command);
                if (!response.IsSuccessStatusCode)
                    throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
                await TryGetProfile();
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

        public async void UpdateWorkAuthorization(UpdateWorkAuthorizationCommand command)
        {
            try
            {
                _loadingService.Show();
                var response = await _authorizedClient.PutAsJsonAsync("UserProfile/WorkAuthorization", command);
                if (!response.IsSuccessStatusCode)
                    throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
                await TryGetProfile();
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
    }
}

