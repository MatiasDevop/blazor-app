using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive.Subjects;
using Enums;
using Microsoft.Extensions.Logging;
using ViewModels.Dtos;

namespace Portal.Blazor.Services
{
    public class PartnerPlanService
    {
        private readonly ILogger<PartnerPlanService> _logger;
        private readonly HttpClient _httpClient;
        private readonly Dictionary<PlanType, BehaviorSubject<List<PartnerPlanDto>>> _partnerPlans = new();

        public IObservable<List<PartnerPlanDto>> this[PlanType planType]
        {
            get
            {
                if (_partnerPlans.ContainsKey(planType)) return _partnerPlans[planType];
                _partnerPlans.Add(planType, new BehaviorSubject<List<PartnerPlanDto>>(new()));
                GetPartnerPlansByType(planType);

                return _partnerPlans[planType];
            }
        }

        public PartnerPlanService(IHttpClientFactory httpClientFactory, ILogger<PartnerPlanService> logger)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient(DefaultHttpClients.Unsecured);
        }

        private async void GetPartnerPlansByType(PlanType planType)
        {
            _logger.LogInformation($"Fetching Plans for {planType}");
            var response = await _httpClient.GetAsync($"PartnerPlan/{(int)planType}");
            if (!response.IsSuccessStatusCode)
                return;
            var partnerPlans = await response.Content.ReadFromJsonAsync<List<PartnerPlanDto>>();
            if (partnerPlans == null)
            {
                _logger.LogInformation($"No plans found for {planType}");
                return;
            }
            _logger.LogInformation($"Found {partnerPlans.Count} plans");
            _partnerPlans[planType].OnNext(partnerPlans);
        }
        
    }
}

