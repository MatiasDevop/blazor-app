using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Enums;
using Portal.Blazor.Extensions;
using ViewModels.Dtos;
using ViewModels.Queries;
using ViewModels.Extensions;

namespace Portal.Blazor.Services
{
    public class MatchingService
    {
        private readonly UserProfileService _userProfileService;
        private readonly ToastService _toastService;
        private readonly LoadingService _loadingService;
        private readonly UserConnectionService _userConnectionService;
        private readonly HttpClient _httpClient;
        private readonly BehaviorSubject<List<PotentialConnectionDto>> _mentorMatches = new(new());
        private readonly BehaviorSubject<List<PotentialConnectionDto>> _connectorMatches = new(new());
        private int _mentorQueryId;
        private int _connectorQueryId;

        public SearchMatchesQuery SearchQuery { get; private set; } = new();

        public IObservable<List<PotentialConnectionDto>> MentorMatches => _mentorMatches;
        public IObservable<List<PotentialConnectionDto>> ConnectorMatches => _connectorMatches;

        public MatchingService(IHttpClientFactory httpClientFactory, UserProfileService userProfileService,
            ToastService toastService, LoadingService loadingService, UserConnectionService userConnectionService)
        {
            _userProfileService = userProfileService;
            _toastService = toastService;
            _loadingService = loadingService;
            _userConnectionService = userConnectionService;
            _httpClient = httpClientFactory.CreateClient(DefaultHttpClients.Secured);
        }

        public async void GetMatches(bool appendResults = false)
        {
            var type = SearchQuery.Type;
            var currentQueryId = type switch
            {
                UserConnectionType.Mentoring => ++_mentorQueryId,
                UserConnectionType.Assisting => ++_connectorQueryId
            };
           
            var matches = await _httpClient.GetFromJsonAsync<List<PotentialConnectionDto>>(
                    QueryStringHelper.Build("Matching", SearchQuery));
            if ((currentQueryId != _mentorQueryId && type is UserConnectionType.Mentoring) ||
                (currentQueryId != _connectorQueryId && type is UserConnectionType.Assisting)) return;
            var subject = type switch
            {
                UserConnectionType.Mentoring => _mentorMatches,
                UserConnectionType.Assisting => _connectorMatches
            };
            if (appendResults)
                subject.AddRange(matches);
            else
                subject.OnNext(matches);
        }

        public void ResetSearchQuery()
        {
            SearchQuery = new();
        }

        public async void DeclineMatch(Guid id)
        {
            var match =
                _mentorMatches.Value.FirstOrDefault(x => x.Id == id) ??
                _connectorMatches.Value.FirstOrDefault(x => x.Id == id);
            if (match == null)
                return;
            await _httpClient.PatchAsync($"Matching/{id}/Decline", null);
            var subject = match.Type switch
            {
                UserConnectionType.Mentoring => _mentorMatches,
                UserConnectionType.Assisting => _connectorMatches
            };
            subject.Remove(match);
        }

        public async Task ApproveMatch(UserConnectionDto dto)
        {
            await _userConnectionService.MakeConnection(dto);
            var match =
                _mentorMatches.Value.FirstOrDefault(x => x.UserId == dto.UserId) ??
                _connectorMatches.Value.FirstOrDefault(x => x.UserId == dto.UserId);
            if (match == null)
                return;
            var subject = match.Type switch
            {
                UserConnectionType.Mentoring => _mentorMatches,
                UserConnectionType.Assisting => _connectorMatches
            };
            subject.Remove(match);
        }
    }
}

