using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Enums;
using Microsoft.Extensions.Logging;
using ViewModels.Dtos;

namespace Portal.Blazor.Services
{
    public class DiscountService
    {
        private readonly ILogger<DiscountService> _logger;
        private readonly HttpClient _httpClient;
        private readonly BehaviorSubject<List<DiscountDto>> _discounts = new(new());

        public IObservable<List<DiscountDto>> Discounts => _discounts.Where(x => x != null);

        public DiscountService(IHttpClientFactory httpClientFactory, ILogger<DiscountService> logger)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient(DefaultHttpClients.Unsecured);
        }

        public async Task<DiscountDto> GetDiscount(string code, DiscountTarget targetType, Guid target)
        {
            var discount = _discounts.Value
                .FirstOrDefault(x => x.Code == code && (x.TargetPlan == null || x.TargetPlan == target));
            if (discount != null)
            {
                _logger.LogInformation($"Discount [{code}] for {targetType} already cached");
                return discount;
            }
            Guid? targetId = target == Guid.Empty ? null : target;
            var response = await _httpClient.GetAsync($"Registration/Discount?code={code}&targetType={(int)targetType}&target={targetId}");
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogInformation($"Discount [{code}] for {targetType} not found");
                return null;
            }
            discount = await response.Content.ReadFromJsonAsync<DiscountDto>();
            _discounts.Value.Add(discount);
            _discounts.OnNext(_discounts.Value);
            
            _logger.LogInformation($"Discount [{discount.Id}] found");
            return discount;
        }
    }
}

