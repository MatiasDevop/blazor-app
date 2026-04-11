using Microsoft.JSInterop;
using System.Reactive.Subjects;

namespace Portal.Blazor.Services
{
    public class BreakpointService
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly ILogger<BreakpointService> _logger;
        private readonly BehaviorSubject<Enums.Breakpoint> _currentBreakpoint = new BehaviorSubject<Enums.Breakpoint>(Enums.Breakpoint.None);
        public IObservable<Enums.Breakpoint> CurrentBreakpoint => _currentBreakpoint;

        public BreakpointService(IJSRuntime jsRuntime, ILogger<BreakpointService> logger)
        {
            _jsRuntime = jsRuntime;
            _logger = logger;
        }

        public async void Init()
        {
            var module = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "/js/BreakpointService.js");
            await module.InvokeVoidAsync("StartBreakpointService", DotNetObjectReference.Create(this));
        }

        [JSInvokable]
        public void UpdateBreakpoint(Enums.Breakpoint breakpoint)
        {
            _currentBreakpoint.OnNext(breakpoint);
        }
    }
}
