using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace Portal.Blazor.Services
{
    public class DocumentService
    {
        private readonly ILogger<DocumentService> _logger;
        private readonly IJSRuntime _jsRuntime;
        private readonly HttpClient _httpClient;
        private readonly HttpClient _authorizedClient;

        private readonly BehaviorSubject<string> _receipt = new(null);

        public IObservable<string> Receipt => _receipt.Where(x => x != null);

        public DocumentService(IHttpClientFactory httpClientFactory, ILogger<DocumentService> logger,
            IJSRuntime jsRuntime)
        {
            _logger = logger;
            _jsRuntime = jsRuntime;
            _httpClient = httpClientFactory.CreateClient(DefaultHttpClients.Unsecured);
            _authorizedClient = httpClientFactory.CreateClient(DefaultHttpClients.Secured);
        }

        public async Task GetReceipt(Guid invoiceId)
        {
            _logger.LogInformation($"Fetching invoice [{invoiceId}]");
            try
            {
                var bytes = await _httpClient.GetByteArrayAsync($"Document/Receipt/{invoiceId}");
                _receipt.OnNext("data:application/pdf;base64," + Convert.ToBase64String(bytes));
            }
            catch (Exception e)
            {
                _logger.LogError($"Expected Invoice [{invoiceId}] to exist", e);
            }
        }

        public async void DownloadInvoice(Guid invoiceId)
        {
            _logger.LogInformation($"Fetching invoice [{invoiceId}]");
            try
            {
                var response = await _authorizedClient.GetAsync($"Document/Invoice/{invoiceId}");
                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException(await response.Content.ReadAsStringAsync(), null, response.StatusCode);

                var fileName = $"{invoiceId}.pdf";
                var bytes = await response.Content.ReadAsByteArrayAsync();
                var fileData = "data:application/pdf;base64," + Convert.ToBase64String(bytes);
                await _jsRuntime.InvokeVoidAsync("downloadFile", fileName, fileData);
            }
            catch (HttpRequestException e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}

