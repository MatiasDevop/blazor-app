using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Portal.Blazor.Extensions;

public static class AuthServiceExtensions
{
    public static IServiceCollection SetupAuth0Service(this IServiceCollection services, IConfiguration configuration)
    {
        // Placeholder for Auth0 configuration
        // Add Auth0 authentication when available
        // Example: services.AddAuth0WebAssemblyAuthentication(options => { ... });

        return services;
    }

    public static IServiceCollection SetupDefaultApiClients(this IServiceCollection services, IConfiguration configuration)
    {
        var apiBaseUrl =
            configuration["ApiBaseUrl"]
            ?? configuration["Api:Url"]
            ?? "http://localhost:5130/api/";

        if (!apiBaseUrl.EndsWith('/'))
        {
            apiBaseUrl += "/";
        }

        services.AddHttpClient(DefaultHttpClients.Secured, client =>
        {
            client.BaseAddress = new Uri(apiBaseUrl);
        });

        services.AddHttpClient(DefaultHttpClients.Unsecured, client =>
        {
            client.BaseAddress = new Uri(apiBaseUrl);
        });

        return services;
    }
}

