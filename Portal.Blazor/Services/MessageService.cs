using System;
using System.Net.Http;
using System.Threading.Tasks;
using Constants;
using Portal.Blazor.Weavy;

namespace Portal.Blazor.Services;

public class MessageService
{
    private readonly HttpClient _httpClient;
    private readonly WeavyService _weavyService;
    private readonly ToastService _toastService;

    public MessageService(IHttpClientFactory httpClientFactory, WeavyService weavyService, ToastService toastService)
    {
        _weavyService = weavyService;
        _toastService = toastService;
        _httpClient = httpClientFactory.CreateClient(DefaultHttpClients.Secured);
    }

    
}

