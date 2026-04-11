using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Portal.Blazor.Extensions;

public static class FluentValidationExtensions
{
    public static IServiceCollection AddFluentValidationHandler(this IServiceCollection services)
    {
        // Add FluentValidation support for Blazor forms
        // This can be expanded based on specific validation needs
        services.AddValidatorsFromAssemblyContaining<Program>();
        
        return services;
    }
}

