using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using Portal.Blazor.Weavy;
using ViewModels.Commands;
using ViewModels.Weavy.Model;

namespace Portal.Blazor.Services {
    public class WeavyService {
        private readonly IJSRuntime _jsRuntime;
        private readonly ToastService _toastService;
        private readonly string _clientId;
        private readonly string _url;
        private readonly HttpClient _httpClient;
        private bool _initialized;
        private IJSObjectReference _objectReference;
        private readonly Subject<string> _appOpened = new();
        
        public string AccessToken { get; private set; }

        public IObservable<string> AppOpened => _appOpened;
        
        public WeavyService(IJSRuntime jsRuntime, IConfiguration configuration, IHttpClientFactory httpClientFactory, ToastService toastService) {
            _jsRuntime = jsRuntime;
            _toastService = toastService;
            _url = configuration.GetSection("Weavy").GetValue<string>("Url");
            _clientId = configuration.GetSection("Weavy").GetValue<string>("ClientId");
            _httpClient = httpClientFactory.CreateClient(DefaultHttpClients.Secured);
        }
        
        private async Task Init()
        {
            if (!_initialized)
            {
                _initialized = true;
                _objectReference = await _jsRuntime.InvokeAsync<IJSObjectReference>("weavy",
                    new object[] {_url, DotNetObjectReference.Create(this)});
            }
        }

        [JSInvokable]
        public async Task<string> GetAccessToken()
        {
            AccessToken = await _httpClient.GetStringAsync("Chat/AccessToken");
            return AccessToken;
        } 
        
        public async ValueTask<SpaceReference> Space(object spaceSelector = null) {
            await Init();
            return new(await _objectReference.InvokeAsync<IJSObjectReference>("space", new object[] { spaceSelector }));
        }

        public async Task SendMessage(Guid userId, string message = null)
        {
            try
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"Chat", UriKind.Relative),
                    Content = JsonContent.Create(new SendChatMessageCommand()
                    {
                        UserId = userId,
                        Message = message
                    })
                };
                request.Headers.Add(Headers.WeavyAuthorization, AccessToken);
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException(await response.Content.ReadAsStringAsync(), null, response.StatusCode);
                var conversation = await response.Content.ReadFromJsonAsync<Conversation>();
                await (await (await Space("global")).App("global-chat")).Open($"/conversations/{conversation!.Id}");
                _appOpened.OnNext("global-chat");
            }
            catch (Exception e)
            {
                _toastService.ShowToast(e.Message, ToastLevel.Error);
            }
        }
    }
}

