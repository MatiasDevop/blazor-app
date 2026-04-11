using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Web;
using Portal.Blazor.Extensions;
using ViewModels.Dtos;
using ViewModels.Queries;

namespace Portal.Blazor.Services;

public class SearchService
{
   
    private readonly BehaviorSubject<List<SearchResultDto>> _results = new(new());
    public IObservable<List<SearchResultDto>> Results => _results;

    private readonly BehaviorSubject<SearchObjectsQuery> query = new(new ());
    public IObservable<SearchObjectsQuery> Query => query;



    private int _searchId;
    private readonly HttpClient _httpClient;
    

    public SearchService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient(DefaultHttpClients.Unsecured);
    }

    public async void Search()
    {
        var currentQuery = query.Value;
        _searchId++;
        if (string.IsNullOrEmpty(currentQuery.SearchText))
        {
            _results.OnNext(new());
            return;
        }
        
        var currentSearchId = _searchId;
        var results =
            await _httpClient.GetFromJsonAsync<List<SearchResultDto>>(QueryStringHelper.Build("Search", query.Value));
        if (currentSearchId != _searchId) return;
        if (currentQuery.Skip == 0)
            _results.OnNext(results);
        else
            _results.AddRange(results);
    }
    
    public void ResetSearchQuery()
    {
        query.OnNext(new SearchObjectsQuery());
    }

    public void UpdateSearchQuery(SearchObjectsQuery newValue)
    {
        query.OnNext(newValue);
        Search();
    }
}

