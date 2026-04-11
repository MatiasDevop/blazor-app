using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Portal.Blazor.Services;

namespace Portal.Blazor.Extensions
{
    public static class CancelableNavigationManagerExtensions
    {
        [JSInvokable(nameof(CancelableNotifyLocationChanged))]
        public static async Task CancelableNotifyLocationChanged(string uri, bool isInterceptedLink)
        {
            Console.WriteLine("Intercepted");
            await CancelableNavigationManager.Instance.SetLocation(uri, isInterceptedLink);
        }
        public static void AddCancelableNavigationManager(this WebAssemblyHostBuilder builder)
        {
            ServiceDescriptor navigationMangerDescriptor = null;
            ServiceDescriptor jsRuntimeDescriptor = null;

            foreach (var serviceRegistration in builder.Services)
            {
                if (serviceRegistration.ServiceType.FullName == "Microsoft.AspNetCore.Components.NavigationManager" &&
                    serviceRegistration.ImplementationInstance != null)
                    navigationMangerDescriptor = serviceRegistration;

                if (serviceRegistration.ServiceType.FullName == "Microsoft.JSInterop.IJSRuntime" &&
                    serviceRegistration.ImplementationInstance != null)
                    jsRuntimeDescriptor = serviceRegistration;

                if (navigationMangerDescriptor != null && jsRuntimeDescriptor != null)
                    break;
            }

            if (navigationMangerDescriptor != null)
            {
                builder.Services.Remove(navigationMangerDescriptor);

                var cancelableNavigationManager = new CancelableNavigationManager(
                    (Microsoft.AspNetCore.Components.NavigationManager) navigationMangerDescriptor
                        .ImplementationInstance, (Microsoft.JSInterop.IJSRuntime) jsRuntimeDescriptor.ImplementationInstance);

                CancelableNavigationManager.Instance = cancelableNavigationManager;

                builder.Services.AddSingleton<Microsoft.AspNetCore.Components.NavigationManager>(sp =>
                    cancelableNavigationManager);

                builder.Services.AddSingleton<CancelableNavigationManager>(sp => cancelableNavigationManager);
            }
        }
    }
}
