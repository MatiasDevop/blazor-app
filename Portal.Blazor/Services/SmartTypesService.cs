using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Microsoft.Extensions.Logging;
using ViewModels.Dtos;

namespace Portal.Blazor.Services
{
    public class SmartTypesService
    {
        private readonly ILogger<SmartTypesService> _logger;
        private readonly HttpClient _httpClient;
        private readonly Dictionary<string, BehaviorSubject<List<SmartCodeDto>>> _smartTypes = new();
        private readonly List<(string,SmartCodeDto)> _temporarySmartCodes = new();

        public IObservable<List<SmartCodeDto>> this[string smartType]
        {
            get
            {
                EnsureSmartType(smartType);
                return _smartTypes[smartType].Where(x => x != null);
            }
        }

        public SmartTypesService(IHttpClientFactory httpClientFactory, ILogger<SmartTypesService> logger)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient(DefaultHttpClients.Unsecured);
        }

        private async void GetSmartTypeByName(string name)
        {
            var response = await _httpClient.GetAsync($"SmartType?name={name}");
            if (!response.IsSuccessStatusCode)
                return;
            var smartType = await response.Content.ReadFromJsonAsync<SmartTypeDto>();
            if (smartType == null) return;
            _smartTypes[name].OnNext(smartType.SmartCodes);
        }

        public SmartCodeDto AddCustomValue(string smartType, string value)
        {
            var customCode = new SmartCodeDto()
            {
                Label = value,
                Code = "CUST"
            };
            _smartTypes[smartType].Value.Add(customCode);
            _smartTypes[smartType].OnNext(_smartTypes[smartType].Value);
            _temporarySmartCodes.Add((smartType,customCode));
            return customCode;
        }

        private void EnsureSmartType(string smartType)
        {
            if (_smartTypes.ContainsKey(smartType))
                return;
            _smartTypes[smartType] = new(new());
            GetSmartTypeByName(smartType);
        }

        public void FlushTemporaryCodes()
        {
            foreach (var (smartType, smartCode) in _temporarySmartCodes)
            {
                _smartTypes[smartType].Value.Remove(smartCode);
            }
            _temporarySmartCodes.Clear();
            foreach (var (_, subject) in _smartTypes)
            {
                subject.OnNext(subject.Value);
            }           
        }
        
        public void AddRange(string smartType, List<SmartCodeDto> smartCodes)
        {
            _logger.LogInformation($"Adding {smartCodes.Count} smart codes to store");
            EnsureSmartType(smartType);
            
            var cachedSmartCodeIds = _smartTypes[smartType].Value.Select(x => x.Id).ToList();
            foreach (var smartCode in smartCodes)
            {
                if (smartCode == null || cachedSmartCodeIds.Contains(smartCode.Id))
                    continue;
                _smartTypes[smartType].Value.Add(smartCode);
            }
            _smartTypes[smartType].OnNext(_smartTypes[smartType].Value);
        }
    }
}

