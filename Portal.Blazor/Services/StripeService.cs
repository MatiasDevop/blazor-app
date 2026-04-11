using Enums;
using Microsoft.JSInterop;
using Portal.Blazor.Models;
using System.Reactive.Subjects;

namespace Portal.Blazor.Services
{
    public class StripeService
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly string _stripeKey;
        private readonly HttpClient _httpClient;
        private readonly BehaviorSubject<StripeStatus> _stripeStatus = new(Enums.StripeStatus.Empty);
        private readonly BehaviorSubject<string> _stripeError = new(null);
        private IJSObjectReference _module;

        public IObservable<StripeStatus> StripeStatus => _stripeStatus;
        public IObservable<string> StripeError => _stripeError;

        public StripeService(IJSRuntime jsRuntime, IConfiguration configuration, IHttpClientFactory httpClientFactory, BreakpointService breakpointService)
        {
            _jsRuntime = jsRuntime;
            _stripeKey = configuration.GetValue<string>("StripeKey");
            _httpClient = httpClientFactory.CreateClient(DefaultHttpClients.Unsecured);
            breakpointService.CurrentBreakpoint.Subscribe(UpdateBreakpoint);
        }

        private void UpdateBreakpoint(Enums.Breakpoint breakpoint)
        {
            _module?.InvokeVoidAsync("UpdateBreakpoint", (int)breakpoint);
        }

        private async Task Initialize()
        {
            if (_module != null) return;
            _module = await _jsRuntime
                .InvokeAsync<IJSObjectReference>("import", "./js/StripeService.js");
            await _module.InvokeVoidAsync("Initialize", _stripeKey, DotNetObjectReference.Create(this));
        }

        public async Task CreateInstance(string elementId)
        {
            await Initialize();
            await _module.InvokeVoidAsync("CreateInstance", elementId);
        }

        public void Detatch()
        {
            _module?.InvokeVoidAsync("Detach");
        }

        public void Destroy()
        {
            _module?.InvokeVoidAsync("Destroy");
        }

        public async Task<StripePaymentMethod> CreatePaymentMethod()
        {
            await Initialize();
            return await _module.InvokeAsync<StripePaymentMethod>("CreatePaymentMethod");
        }

        public async Task<string> GetPaymentId(string secret)
        {
            return await _module.InvokeAsync<string>("GetPaymentId", secret);
        }

        [JSInvokable]
        public void UpdateStripeStatus(StripeStatus status, string error = null)
        {
            _stripeStatus.OnNext(status);
            _stripeError.OnNext(error);
        }

        public async Task<string> GetPaymentMethodCustomerId() =>
            await _httpClient.GetStringAsync("PaymentMethod/generate-customer");
    }
}

