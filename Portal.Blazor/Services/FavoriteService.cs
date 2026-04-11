using System;
using System.Collections.Generic;
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
    public class FavoriteService
    {
        private readonly ILogger<FavoriteService> _logger;
        private readonly UserProfileService _userProfileService;
        private readonly HttpClient _httpClient;

        public FavoriteService(IHttpClientFactory httpClientFactory, ILogger<FavoriteService> logger, UserProfileService userProfileService)
        {
            _logger = logger;
            _userProfileService = userProfileService;
            _httpClient = httpClientFactory.CreateClient(DefaultHttpClients.Secured);
        }

        public async Task AddUserFavorite(Guid targetId, FavoriteType type)
        {
            var response = await _httpClient.PostAsJsonAsync("Favorite", new UserFavoriteDto()
            {
                Type = type,
                TargetId = targetId
            });
            if (!response.IsSuccessStatusCode)
                return;
            await _userProfileService.TryGetProfile();
        }

        public async Task RemoveUserFavorite(Guid favoriteId)
        {
            var response = await _httpClient.DeleteAsync($"Favorite/{favoriteId}");
            if (!response.IsSuccessStatusCode)
                return;
            await _userProfileService.TryGetProfile();
        }
    }
}

