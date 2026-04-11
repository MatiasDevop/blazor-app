using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using Portal.Blazor.Models;

namespace Portal.Blazor.Services
{
    public class CancelableNavigationManager : Microsoft.AspNetCore.Components.NavigationManager
    {
        private Microsoft.AspNetCore.Components.NavigationManager _underlyingNavigationManager;
        private readonly IJSRuntime _jsRuntime;
        private int _currentHistoryState = -1;
        public Func<string, string, Task<bool>> ShouldCancelAsync { get; set; }

        public static CancelableNavigationManager Instance { get; set; }

        public CancelableNavigationManager(
            Microsoft.AspNetCore.Components.NavigationManager underlyingNavigationManager, IJSRuntime jsRuntime)
        {
            _underlyingNavigationManager = underlyingNavigationManager;
            _jsRuntime = jsRuntime;

            Initialize(underlyingNavigationManager.BaseUri, underlyingNavigationManager.Uri);
            UpdateCurrentHistoryState();
        }

        protected override void EnsureInitialized()
        {
            Initialize(_underlyingNavigationManager.BaseUri, _underlyingNavigationManager.Uri);
        }

        private async Task UpdateCurrentHistoryState()
        {
            var currentHistoryState = await _jsRuntime.InvokeAsync<int>("getHistoryStateOrder");

            if (currentHistoryState == -1)
            {
                _currentHistoryState++;
                await _jsRuntime.InvokeVoidAsync("history.replaceState", _currentHistoryState, null);
            }
            else
                _currentHistoryState = currentHistoryState;
        }

        public async Task SetLocation(string uri, bool isInterceptedLink)
        {
            var previousHistoryState = _currentHistoryState;
            await UpdateCurrentHistoryState();
            
            var cancel = false;
            if (ShouldCancelAsync != null)
                cancel = await ShouldCancelAsync.Invoke(Uri, uri);
            
            if (!cancel)
            {
                Uri = uri;
                NotifyLocationChanged(isInterceptedLink);
                return;
            }

            if (previousHistoryState == -1)
                return;
            
            if (_currentHistoryState > previousHistoryState)
                await _jsRuntime.InvokeVoidAsync("history.back");
            
            else if (_currentHistoryState < previousHistoryState)
                await _jsRuntime.InvokeVoidAsync("history.forward");

            _currentHistoryState = previousHistoryState;
        }

        protected override async void NavigateToCore(string uri, bool forceLoad)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            var cancel = false;
            if (ShouldCancelAsync != null)
                cancel = await ShouldCancelAsync.Invoke(Uri, uri);

            if (cancel)
                return;

            await _jsRuntime.InvokeVoidAsync("Blazor._internal.navigationManager.navigateTo", uri, forceLoad, false);
        }
    }
}
