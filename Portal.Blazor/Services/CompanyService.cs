using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ViewModels.Commands;
using ViewModels.Dtos;
using ViewModels.ViewModels;

namespace Portal.Blazor.Services
{
    public class CompanyService
    {
        private readonly ILogger<CompanyService> _logger;
        private readonly LoadingService _loadingService;
        private readonly ToastService _toastService;
        private readonly SmartTypesService _smartTypesService;
        private readonly HttpClient _httpClient;
        private readonly HttpClient _authorizedClient;
        private readonly BehaviorSubject<List<CompanyDto>> _spotlightCompanies = new(new());
        private readonly BehaviorSubject<Dictionary<Guid, CompanyProfileDto>> _companySearchResults = new(new());
        private readonly Dictionary<Guid, BehaviorSubject<FullCompanyDto>> _companies = new();
        private readonly Subject<List<InvoiceDto>> _invoices = new();
        private readonly Dictionary<Guid, BehaviorSubject<string>> _logos = new();
        public IObservable<List<CompanyDto>> SpotlightCompanies => _spotlightCompanies;
        public IObservable<Dictionary<Guid, CompanyProfileDto>> CompanySearchResults => _companySearchResults;
        public IObservable<List<InvoiceDto>> Invoices => _invoices;
        private List<Guid> _temporaryIds = new();

        public CompanyService(IHttpClientFactory httpClientFactory, ILogger<CompanyService> logger, LoadingService loadingService, ToastService toastService, SmartTypesService smartTypesService)
        {
            _logger = logger;
            _loadingService = loadingService;
            _toastService = toastService;
            _smartTypesService = smartTypesService;
            _httpClient = httpClientFactory.CreateClient(DefaultHttpClients.Unsecured);
            _authorizedClient = httpClientFactory.CreateClient(DefaultHttpClients.Secured);
        }

        public IObservable<FullCompanyDto> Company(Guid id)
        {
            if (!_companies.ContainsKey(id))
            {
                _companies[id] = new BehaviorSubject<FullCompanyDto>(null);
                GetCompany(id);
            }
            return _companies[id].Where(x => x is not null);
        }
        public IObservable<string> CompanyImage(Guid id)
        {
            if (!_logos.ContainsKey(id))
            {
                _logos[id] = new BehaviorSubject<string>(null);
                GetLogo(id);
            }
            return _logos[id].Where(x => x is not null);
        }

        public async void GetSpotlightCompanies(int companiesToGet = 4)
        {
            _logger.LogInformation($"[{nameof(GetSpotlightCompanies)}] - Attempting to retrieve spotlight companies");
            if (_spotlightCompanies.Value.Any()) return;

            try
            {
                var companiesContent = await _httpClient.GetAsync($"Company/{companiesToGet}");

                if (companiesContent.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"[{nameof(GetSpotlightCompanies)}] - Successfully Retrieved Data for Spotlight Companies");
                    var content = await companiesContent.Content.ReadAsStringAsync();
                    _logger.LogInformation($"[{nameof(GetSpotlightCompanies)}] - Spotlight Companies Data: {content}");
                    var companies = JsonSerializer.Deserialize<List<CompanyDto>>(content) ?? new List<CompanyDto>();
                    _logger.LogInformation($"[{nameof(GetSpotlightCompanies)}] - Found {companies.Count} companies");
                    _spotlightCompanies.OnNext(companies);
                }
                else
                {
                    _logger.LogInformation($"[{nameof(GetSpotlightCompanies)}] - Unable to retrieve companies");
                    _spotlightCompanies.OnNext(new List<CompanyDto>());
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, $"[{nameof(GetSpotlightCompanies)}] - Failed to retrieve companies. Falling back to empty list.");
                _spotlightCompanies.OnNext(new List<CompanyDto>());
            }
        }

        public async void SearchCompanies(string searchText)
        {
            var companies =
                await _httpClient.GetFromJsonAsync<List<CompanyProfileDto>>($"Company/search?name={searchText}");
            var dict = _companySearchResults.Value;
            _logger.LogInformation($"Found {companies.Count} companies");
            foreach (var company in companies)
            {
                dict[company.Id] = company;
            }
            _companySearchResults.OnNext(dict);
        }

        public CompanyProfileDto TryAddCompany(CompanyProfileDto company)
        {
            var existing = _companySearchResults.Value.Select(x => x.Value).FirstOrDefault(existing =>
                existing.Name.ToLower() == company.Name.ToLower() &&
                existing.State == company.State &&
                existing.City.ToLower() == company.City.ToLower()
            );
            if (existing != null)
            {
                _logger.LogInformation($"Company [{existing.Name}] already exists");
                return existing;
            }

            var id = Guid.NewGuid();
            _temporaryIds.Add(id);
            _companySearchResults.Value[id] = company;
            _companySearchResults.OnNext(_companySearchResults.Value);

            _logger.LogInformation($"Created temporary company [{id}]");
            return company;
        }

        public void ClearTemporaryIds()
        {
            foreach (var id in _temporaryIds)
            {
                _companySearchResults.Value.Remove(id);
            }
            _companySearchResults.OnNext(_companySearchResults.Value);
            _temporaryIds.Clear();
        }

        public void AddRange(IEnumerable<CompanyProfileDto> companies)
        {
            _logger.LogInformation($"Adding {companies.Count()} companies to store");
            foreach (var company in companies)
            {
                _companySearchResults.Value[company.Id] = company;
            }
            _companySearchResults.OnNext(_companySearchResults.Value);
        }
        public async void GetCompany(Guid id)
        {
            try
            {
                _logger.LogWarning("Attempting to retrieve Company");
                var profile = await _httpClient.GetFromJsonAsync<FullCompanyDto>($"Company/{id}");

                _companies[id].OnNext(profile);
            }
            catch (HttpRequestException e)
            {
                if (e.Message.Contains(((int)HttpStatusCode.Forbidden).ToString())
                    || e.Message.Contains(((int)HttpStatusCode.NotFound).ToString()))
                {
                    _logger.LogError(e, "Unable to retrieve company");
                    //_navigationManager.NavigateTo("/");
                }
            }
        }

        private async void GetLogo(Guid id)
        {
            var response = await _httpClient.GetAsync($"Company/{id}/Logo");
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
                var response = await _authorizedClient.PutAsJsonAsync($"Company/{id}/Logo", attachment);
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
                await _authorizedClient.PutAsJsonAsync($"Company/{id}/Video", url);
                GetCompany(id);
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
                await _authorizedClient.PutAsJsonAsync($"Company/{id}/Description", description);
                GetCompany(id);
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

        public async void UpdateMultiSelection(Guid id, UpdateMultiSelectionCommand command)
        {
            try
            {
                _loadingService.Show();
                await _authorizedClient.PutAsJsonAsync($"Company/{id}/MultiSelection", command);
                _smartTypesService.FlushTemporaryCodes();
                GetCompany(id);
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

        public async void UpdateAffinityGroup(Guid id, UpdateAffinityGroupCommand command)
        {
            try
            {
                _loadingService.Show();
                await _authorizedClient.PutAsJsonAsync($"Company/{id}/AffinityGroup", command);
                GetCompany(id);
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

        public async void UpdateCompanyDocument(Guid id, CompanyDocumentDto dto)
        {
            try
            {
                _loadingService.Show();
                await _authorizedClient.PutAsJsonAsync($"Company/{id}/Document", dto);
                GetCompany(id);
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

        public async void DeleteCompanyDocument(Guid id, Guid documentId)
        {
            try
            {
                _loadingService.Show();
                var response = await _authorizedClient.DeleteAsync($"Company/{id}/Document/{documentId}");
                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException(await response.Content.ReadAsStringAsync(), null,
                        response.StatusCode);
                GetCompany(id);
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

        public async Task<List<UserLabelVm>> GetAvailableEmployees(Guid id)
        {
            try
            {
                return await _authorizedClient.GetFromJsonAsync<List<UserLabelVm>>($"Company/{id}/Employee/Available");
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
                await _authorizedClient.PostAsJsonAsync($"Company/{id}/Employee", dto);
                GetCompany(id);
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
                var response = await _authorizedClient.DeleteAsync($"Company/{id}/Employee/{connectionId}");
                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException(await response.Content.ReadAsStringAsync(), null, response.StatusCode);
                GetCompany(id);
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
                var response = await _authorizedClient.PutAsync($"Company/{id}/Transfer/{userId}", null);
                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException(await response.Content.ReadAsStringAsync(), null, response.StatusCode);
                GetCompany(id);
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

        public async void UpdateCompanyProfile(Guid id, UpdateCompanyProfileCommand command)
        {
            try
            {
                _loadingService.Show();
                await _authorizedClient.PutAsJsonAsync($"Company/{id}", command);
                GetCompany(id);
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
                var response = await _authorizedClient.PutAsJsonAsync($"Company/{id}/SocialLinks", command);
                if (!response.IsSuccessStatusCode)
                    throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
                GetCompany(id);
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

        public async void UpdateWorkAuthorization(Guid id, UpdateWorkAuthorizationCommand command)
        {
            try
            {
                _loadingService.Show();
                var response = await _authorizedClient.PutAsJsonAsync($"Company/{id}/WorkAuthorization", command);
                if (!response.IsSuccessStatusCode)
                    throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
                GetCompany(id);
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
                var invoices = await _authorizedClient.GetFromJsonAsync<List<InvoiceDto>>($"Company/{id}/Invoices");
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

        public async void UpdateMajors(Guid id, List<EducationFocusDto> educationFocuses)
        {
            try
            {
                _loadingService.Show();
                await _authorizedClient.PutAsJsonAsync($"Company/{id}/Majors", educationFocuses);
                GetCompany(id);
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

