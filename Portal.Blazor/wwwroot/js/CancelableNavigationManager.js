(function() {
    Blazor._internal.navigationManager.listenForNavigationEvents(async (uri, intercepted) => {
        await DotNet.invokeMethodAsync(
            'Portal.Blazor',
            'CancelableNotifyLocationChanged',
            uri,
            intercepted
        );
    });
    window.getHistoryStateOrder = () => {
        return typeof history.state === 'number' ? history.state : -1;
    };
})();