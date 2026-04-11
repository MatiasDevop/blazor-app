using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ViewModels.Commands;
using ViewModels.Dtos;
using ViewModels.ViewModels;

namespace Portal.Blazor.Services
{
    public class SchoolService
    {
        private readonly ILogger<SchoolService> _logger;
        private readonly LoadingService _loadingService;
        private readonly ToastService _toastService;
        private readonly HttpClient _httpClient;
        private readonly HttpClient _authorizedClient;
        private readonly BehaviorSubject<List<CareerCenterCardViewModel>> _careerCenterSchools = new(new());
        private readonly BehaviorSubject<Dictionary<Guid, SchoolDto>> _schoolSearchResults = new(new());
        private readonly Dictionary<Guid, BehaviorSubject<FullCareerCenterDto>> _careerCenters = new();
        private readonly Dictionary<Guid, BehaviorSubject<string>> _logos = new();
        private readonly Subject<List<InvoiceDto>> _invoices = new();
        public IObservable<List<CareerCenterCardViewModel>> CareerCenterSchools => _careerCenterSchools;
        public IObservable<Dictionary<Guid, SchoolDto>> SchoolSearchResults => _schoolSearchResults;
        public IObservable<List<InvoiceDto>> Invoices => _invoices;
        private List<Guid> _temporaryIds = new();
        
        public SchoolService(IHttpClientFactory httpClientFactory, ILogger<SchoolService> logger, LoadingService loadingService, ToastService toastService)
        {
            _logger = logger;
            _loadingService = loadingService;
            _toastService = toastService;
            _httpClient = httpClientFactory.CreateClient(DefaultHttpClients.Unsecured);
            _authorizedClient = httpClientFactory.CreateClient(DefaultHttpClients.Secured);
        }
        
        public IObservable<FullCareerCenterDto> CareerCenter(Guid id)
        {
            if (!_careerCenters.ContainsKey(id))
            {
                _careerCenters[id] = new BehaviorSubject<FullCareerCenterDto>(null);
                GetCareerCenter(id);
            }
            return _careerCenters[id].Where(x => x is not null);
        }
        public IObservable<string> Logo(Guid id)
        {
            if (!_logos.ContainsKey(id))
            {
                _logos[id] = new BehaviorSubject<string>(null);
                GetLogo(id);
            }
            return _logos[id].Where(x => x is not null);
        }

        public async void GetCareerCenterSchools(int schoolsToGet = 4)
        {
            if (_careerCenterSchools.Value.Any()) return;
            var schools = await _httpClient.GetFromJsonAsync<List<CareerCenterCardViewModel>>($"School/{schoolsToGet}");
            _careerCenterSchools.OnNext(schools);
        }
        
        public async void SearchSchools(string searchText, bool excludeChildren = false)
        {
            var schools =
                await _httpClient.GetFromJsonAsync<List<SchoolDto>>($"School/search?name={searchText}&excludeChildren={excludeChildren}");
            var dict = _schoolSearchResults.Value;
            foreach (var school in schools)
            {
                dict[school.Id] = school;
            }
            _schoolSearchResults.OnNext(dict);
        }

        public SchoolDto TryAddSchool(SchoolDto school)
        {
            var existing = _schoolSearchResults.Value.Select(x => x.Value).FirstOrDefault(existing =>
                existing.DisplayName.ToLower() == school.DisplayName.ToLower() &&
                existing.State == school.State &&
                existing.City.ToLower() == school.City.ToLower());
            if (existing != null)
                return existing;
            var id = Guid.NewGuid();
            _temporaryIds.Add(id);
            _schoolSearchResults.Value[id] = school;
            _schoolSearchResults.OnNext(_schoolSearchResults.Value);
            return school;
        }

        public void ClearTemporaryIds()
        {
            foreach (var id in _temporaryIds)
            {
                _schoolSearchResults.Value.Remove(id);
            }
            _schoolSearchResults.OnNext(_schoolSearchResults.Value);
            _temporaryIds.Clear();
        }
        
        public void AddRange(IEnumerable<SchoolDto> schools)
        {
            foreach (var school in schools)
            {
                _schoolSearchResults.Value[school.Id] = school;
            }
            _schoolSearchResults.OnNext(_schoolSearchResults.Value);
        }
        
        public async void GetCareerCenter(Guid id)
        {
            try
            {
                _logger.LogWarning("Attempting to retrieve User Profile");
                var profile = await _httpClient.GetFromJsonAsync<FullCareerCenterDto>($"School/{id}");
                
                _careerCenters[id].OnNext(profile);
            }
            catch (HttpRequestException e)
            {
                if (e.Message.Contains(((int) HttpStatusCode.Forbidden).ToString())
                    || e.Message.Contains(((int) HttpStatusCode.NotFound).ToString()))
                {
                    _logger.LogError(e, "Unable to retrieve profile");
                    //_navigationManager.NavigateTo("/");
                }
            }
        }

        private async void GetLogo(Guid id)
        {
            var response = await _httpClient.GetAsync($"School/{id}/Logo");
            if (response.StatusCode == HttpStatusCode.NotFound)
                return;

            var contentType = response.Content.Headers.ContentType?.ToString();
            var imageResult = await response.Content.ReadAsByteArrayAsync();
            var imageBase64 = Convert.ToBase64String(imageResult);
            _logos[id].OnNext($"data:{contentType};base64, {imageBase64}");
        }
        
        public async void UpdateLogo(Guid id, AttachmentDto attachment)
        {
            try
            {
                _loadingService.Show();
                var response = await _authorizedClient.PutAsJsonAsync($"School/{id}/Logo", attachment);
                if (!response.IsSuccessStatusCode)
                    throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
                GetLogo(id);
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
        
        public async void UpdateVideo(Guid id, string url)
        {
            try
            {
                _loadingService.Show();
                await _authorizedClient.PutAsJsonAsync($"School/{id}/Video", url);
                GetCareerCenter(id);
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
        
        public async void UpdateDescription(Guid id, string description)
        {
            try
            {
                _loadingService.Show();
                await _authorizedClient.PutAsJsonAsync($"School/{id}/Description", description);
                GetCareerCenter(id);
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
        
        public async Task<List<UserLabelVm>> GetAvailableEmployees(Guid id)
        {
            try
            {
                return await _authorizedClient.GetFromJsonAsync<List<UserLabelVm>>($"School/{id}/Employee/Available");
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                    _toastService.ShowToast(e.Message, ToastLevel.Error, "Not Found");
                else
                    _toastService.ShowToast(e.Message, ToastLevel.Error, "Unknown Error");
                return new();
            }
        }
        
        public async void UpdateEmployeePermissions(Guid id, OrgUserConnectionDto dto)
        {
            try
            {
                _loadingService.Show();
                await _authorizedClient.PostAsJsonAsync($"School/{id}/Employee", dto);
                GetCareerCenter(id);
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
        
        public async void RemoveEmployee(Guid id, Guid connectionId)
        {
            try
            {
                _loadingService.Show();
                var response = await _authorizedClient.DeleteAsync($"School/{id}/Employee/{connectionId}");
                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException(await response.Content.ReadAsStringAsync(), null, response.StatusCode);
                GetCareerCenter(id);
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
        
        public async void TransferClaim(Guid id, Guid userId)
        {
            try
            {
                _loadingService.Show();
                var response = await _authorizedClient.PutAsync($"School/{id}/Transfer/{userId}", null);
                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException(await response.Content.ReadAsStringAsync(), null, response.StatusCode);
                GetCareerCenter(id);
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
        
        public async void UpdateCareerCenterProfile(Guid id, UpdateCareerCenterProfileCommand command)
        {
            try
            {
                _loadingService.Show();
                await _authorizedClient.PutAsJsonAsync($"School/{id}", command);
                GetCareerCenter(id);
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
        
        public async void UpdateSocialLinks(Guid id, UpdateSocialLinksCommand command)
        {
            try
            {
                _loadingService.Show();
                var response = await _authorizedClient.PutAsJsonAsync($"School/{id}/SocialLinks", command);
                if (!response.IsSuccessStatusCode)
                    throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
                GetCareerCenter(id);
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
        
        public async void GetInvoicesAsync(Guid id)
        {
            try
            {
                var invoices =  await _authorizedClient.GetFromJsonAsync<List<InvoiceDto>>($"School/{id}/Invoices");
                _invoices.OnNext(invoices);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                    _toastService.ShowToast(e.Message, ToastLevel.Error, "Not Found");
                if (e.StatusCode == HttpStatusCode.Forbidden)
                    _toastService.ShowToast(e.Message, ToastLevel.Error, "Not Found");
                else
                    _toastService.ShowToast(e.Message, ToastLevel.Error, "Unknown Error");
            }
        }
        
        public async void UpdateCareerCenterDocument(Guid id, CareerCenterDocumentDto dto)
        {
            try
            {
                _loadingService.Show();
                await _authorizedClient.PutAsJsonAsync($"School/{id}/Document", dto);
                GetCareerCenter(id);
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
    }
}

