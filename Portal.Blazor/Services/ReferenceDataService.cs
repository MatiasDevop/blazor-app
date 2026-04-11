using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive.Subjects;
using ViewModels.Dtos;

namespace Portal.Blazor.Services
{
    public class ReferenceDataService
    {
        private readonly HttpClient _httpClient;

        private readonly BehaviorSubject<Dictionary<Guid, EducationFocusDto>> _educationFocuses = new(new());

        public IObservable<Dictionary<Guid, EducationFocusDto>> EducationFocuses => _educationFocuses;

        public ReferenceDataService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(DefaultHttpClients.Unsecured);
        }

        public async void GetEducationFocuses()
        {
            if (_educationFocuses.Value.Any())
                return;
            var response = await _httpClient.GetFromJsonAsync<List<EducationFocusDto>>("ReferenceData/EducationFocus");
            var dict = response.ToDictionary(x => x.Id);
            _educationFocuses.OnNext(dict);
        }

        public void AddEducationFocus(EducationFocusDto educationFocus)
        {
            _educationFocuses.Value[Guid.NewGuid()] = educationFocus;
            _educationFocuses.OnNext(_educationFocuses.Value);
        }
    }
}

