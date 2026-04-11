using Microsoft.Extensions.DependencyInjection;
using Portal.Rcl.Permissions.Services;

namespace Portal.Blazor.Extensions;

public static class PermissionsRclExtensions
{
    public static IServiceCollection AddPermissionsRcl(this IServiceCollection services)
    {
        services.AddScoped<IOrgSelectionService, OrgSelectionService>();
        return services;
    }
}

