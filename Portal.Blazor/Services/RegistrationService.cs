using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using ViewModels.Commands;
using ViewModels.Queries;
using ViewModels.Requests.Endpoints.UserProfile;

namespace Portal.Blazor.Services
{
    public class RegistrationService
    {
        private readonly TransitionService _transitionService;
        private readonly DocumentService _documentService;
        private readonly SmartTypesService _smartTypesService;
        private readonly HttpClient _httpClient;

        public RegistrationService(IHttpClientFactory httpClientFactory, TransitionService transitionService, DocumentService documentService, SmartTypesService smartTypesService)
        {
            _transitionService = transitionService;
            _documentService = documentService;
            _smartTypesService = smartTypesService;
            _httpClient = httpClientFactory.CreateClient(DefaultHttpClients.Unsecured);
        }
        
        public async Task StudentSignupAsync(RegisterStudentCommand command,
            CancellationToken cancellationToken = default)
        {
            var request = new RegisterStudentRequest(Guid.NewGuid(), command);
            var response = await _httpClient.PostAsJsonAsync("userprofile/student", request, cancellationToken);
            if (response.StatusCode == HttpStatusCode.Conflict)
                throw new ArgumentException(await response.Content.ReadAsStringAsync(cancellationToken));
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync(cancellationToken));
            _smartTypesService.FlushTemporaryCodes();
        }

        public async Task EmployeeSignupAsync(RegisterEmployeeCommand command,
            CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsJsonAsync("Registration/Employees", command, cancellationToken);
            if (response.StatusCode == HttpStatusCode.Conflict)
                throw new ArgumentException(await response.Content.ReadAsStringAsync(cancellationToken));
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<RegisterEmployeeCommandResult>(cancellationToken: cancellationToken);
                _transitionService.SetUserId(result.UserId);
                _smartTypesService.FlushTemporaryCodes();
            }
            else
                throw new Exception(await response.Content.ReadAsStringAsync(cancellationToken));
        }
        
        public async Task CompanySignupAsync(RegisterCompanyCommand command,
            CancellationToken cancellationToken = default)
        {
            var request = new RegisterCompanyRequest(Guid.NewGuid(), command);
            var response = await _httpClient.PostAsJsonAsync("userprofile/company", request, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<RegisterCompanyResult>(cancellationToken: cancellationToken);
                _smartTypesService.FlushTemporaryCodes();
                _transitionService.SetUserId(result.UserId);
                return;
            }
            var error = await response.Content.ReadAsStringAsync(cancellationToken);
            switch (response.StatusCode)
            {
                case HttpStatusCode.FailedDependency:
                    throw new InvalidOperationException(error);
                case HttpStatusCode.Conflict:
                    throw new ArgumentException(error);
                case HttpStatusCode.PaymentRequired:
                    throw new ApplicationException(error);
                default:
                    throw new Exception(error);
            }
        }
        

        public async Task CareerCenterSignupAsync(RegisterCareerCenterCommand command,
            CancellationToken cancellationToken = default)
        {
            var request = new RegisterCareerCenterRequest(Guid.NewGuid(), command);
            var response = await _httpClient.PostAsJsonAsync("userprofile/careercenter", request, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<RegisterCareerCenterResult>(cancellationToken: cancellationToken);
                _smartTypesService.FlushTemporaryCodes();
                _transitionService.SetUserId(result.UserId);
                return;
            }
            var error = await response.Content.ReadAsStringAsync(cancellationToken);
            switch (response.StatusCode)
            {
                case HttpStatusCode.FailedDependency:
                    throw new InvalidOperationException(error);
                case HttpStatusCode.Conflict:
                    throw new ArgumentException(error);
                case HttpStatusCode.PaymentRequired:
                    throw new ApplicationException(error);
                default:
                    throw new Exception(error);
            }
        }
        
        public async Task<EmailExistsQueryResult> CheckIfEmailExistsAsync(string email,
            CancellationToken cancellationToken = default) =>
            await _httpClient.GetFromJsonAsync<EmailExistsQueryResult>($"Registration/EmailExists?email={HttpUtility.UrlEncode(email)}");
        
    }
}

