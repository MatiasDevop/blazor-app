using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using ViewModels.Commands;
using ViewModels.Dtos;
using ViewModels.ViewModels;

namespace Portal.Blazor.Services
{
    public class TransitionService
    {
        private readonly ILogger<TransitionService> _logger;
        private readonly DocumentService _documentService;
        private readonly CompanyService _companyService;
        private readonly SchoolService _schoolService;
        private readonly NavigationManager _navigationManager;
        private readonly HttpClient _httpClient;
        private readonly HttpClient _authorizedClient;
        
        private Guid _userId;

        public TransitionService(IHttpClientFactory httpClientFactory, ILogger<TransitionService> logger, DocumentService documentService, CompanyService companyService, SchoolService schoolService, NavigationManager navigationManager)
        {
            _logger = logger;
            _documentService = documentService;
            _companyService = companyService;
            _schoolService = schoolService;
            _navigationManager = navigationManager;
            _httpClient = httpClientFactory.CreateClient(DefaultHttpClients.Unsecured);
            _authorizedClient = httpClientFactory.CreateClient(DefaultHttpClients.Secured);
        }

        public void SetUserId(Guid userId)
        {
            _userId = userId;
        }

        public async Task EnableTransitionAsync()
        {
            await _authorizedClient.PutAsync($"Transition/Enable", null);
        }

        public async Task StartTransitionAsync(AccountType accountType)
        {
            _logger.LogInformation($"Starting transition to {accountType}");
            
            if (_userId == Guid.Empty)
                throw new ArgumentNullException("UserId not set");

            _logger.LogInformation($"Starting transition for [{_userId}] to {accountType}");
            var response = await _httpClient.PutAsync($"Transition/{_userId}/Start", null);
            if (!response.IsSuccessStatusCode)
                throw new ArgumentNullException($"{_userId} Cannot be transitioned");
            
            _navigationManager.NavigateTo($"transition/{_userId}/{accountType}");
        }
        
        public async Task<UserProfileDto> GetTransitioningUser(Guid userId)
        {
            try
            {
                var vm = await _httpClient.GetFromJsonAsync<TransitioningUserVm>($"Transition/{userId}");

                _companyService.AddRange(vm.Companies);
                _schoolService.AddRange(vm.Schools);

                return vm;
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                    throw new ArgumentException($"{_userId} Cannot be transitioned", e);
                throw;
            }
        }

        public async Task EmployeeTransitionAsync(RegisterEmployeeCommand command, CancellationToken cancellationToken = default)
        {
            if (command.Id == Guid.Empty)
                throw new ArgumentNullException("UserId not set");
            var response = await _httpClient.PostAsJsonAsync($"Transition/{command.Id}/Employee", command, cancellationToken);
            if (response.StatusCode == HttpStatusCode.Conflict)
                throw new ArgumentException(await response.Content.ReadAsStringAsync(cancellationToken));
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync(cancellationToken));
        }
        
        
        public async Task CompanyTransitionAsync(RegisterCompanyCommand command, CancellationToken cancellationToken = default)
        {
            if (command.Id == Guid.Empty)
                throw new ArgumentNullException("UserId not set");
            var response = await _httpClient.PostAsJsonAsync($"Transition/{command.Id}/Company", command, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<RegisterOrganizationCommandResult>(cancellationToken: cancellationToken);
                await _documentService.GetReceipt(result.InvoiceId);
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
        
        public async Task CareerCenterTransitionAsync(RegisterCareerCenterCommand command, CancellationToken cancellationToken = default)
        {
            if (command.Id == Guid.Empty)
                throw new ArgumentNullException("UserId not set");
            var response = await _httpClient.PostAsJsonAsync($"Transition/{command.Id}/CareerCenter", command, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<RegisterOrganizationCommandResult>(cancellationToken: cancellationToken);
                await _documentService.GetReceipt(result.InvoiceId);
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
        
        
    }
}

