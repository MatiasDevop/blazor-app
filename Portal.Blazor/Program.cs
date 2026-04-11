using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using FluentValidation;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Portal.Blazor;
using Portal.Blazor.Extensions;
using Portal.Blazor.Jobs.Services;
using Serilog;
using Serilog.Exceptions;
using Serilog.Extensions.Logging;
using Validation.FrontEnd.JobApplication;
using Validation.FrontEnd.JobPost;
using ViewModels.Dtos;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

var sessionGuid = Guid.NewGuid();

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .Enrich.WithExceptionDetails()
    .WriteTo.BrowserConsole()
    // Datadog logs can be enabled if needed
    // .WriteTo.DatadogLogs("f40d2edbdac474d59d4c688802635535", service: "CPCC-Portal", host: $"browser-wasm-{sessionGuid}")
    .CreateLogger();

Log.Logger.Information($"SessionId: {sessionGuid}");

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<Microsoft.AspNetCore.Components.Web.HeadOutlet>("head::after");

Log.Logger.Information($"SessionId: {sessionGuid} - App Root Rendered");

builder.Logging.SetMinimumLevel(builder.Configuration.GetSection("Logging")
    .GetSection("LogLevel").GetValue<LogLevel>("Default"));

builder.Logging.AddProvider(new SerilogLoggerProvider());

var logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();

logger.LogInformation($"SessionId: {sessionGuid} - SeriLog configured");

// Authorization services are required for CascadingAuthenticationState
builder.Services.AddAuthorizationCore();

// Skip Auth0 setup in Development to allow local runs without external auth
var isDev = builder.HostEnvironment.IsDevelopment();
if (!isDev)
{
    builder.Services.SetupAuth0Service(builder.Configuration);
    builder.Services.SetupDefaultApiClients(builder.Configuration);
    logger.LogInformation($"SessionId: {sessionGuid} - Authentication Services Configured");
}
else
{
    logger.LogInformation($"SessionId: {sessionGuid} - Skipping Auth setup in Development");
    // Setup default HTTP clients for development
    builder.Services.SetupDefaultApiClients(builder.Configuration);

    // Minimal AuthenticationStateProvider for dev so DI can resolve it
    builder.Services.AddScoped<AuthenticationStateProvider, Portal.Blazor.Services.DevAuthenticationStateProvider>();
}

// Ensure SignOutSessionStateManager is available even when full OIDC auth is not configured (e.g., Dev)
builder.Services.AddScoped<SignOutSessionStateManager>();

builder.Services.AddDevExpressBlazor();
builder.Services.AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();

builder.Services.AddBlazoredModal();
builder.Services.AddScoped<ToastService>();
builder.Services.AddFluentValidationHandler();


logger.LogInformation($"SessionId: {sessionGuid} - Component Services Configured");

builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<UserProfileService>();
builder.Services.AddScoped<SchoolService>();
builder.Services.AddScoped<SmartTypesService>();
builder.Services.AddScoped<ReferenceDataService>();
builder.Services.AddScoped<LoadingService>();
builder.Services.AddScoped<AuthStateService>();
builder.Services.AddScoped<BreakpointService>();
builder.Services.AddScoped<RegistrationService>();
builder.Services.AddScoped<PartnerPlanService>();
builder.Services.AddScoped<DiscountService>();
builder.Services.AddScoped<StripeService>();
builder.Services.AddScoped<TransitionService>();
builder.Services.AddScoped<DocumentService>();
builder.Services.AddScoped<FavoriteService>();
builder.Services.AddScoped<SearchService>();
builder.Services.AddScoped<MatchingService>();
builder.Services.AddScoped<UserConnectionService>();
builder.Services.AddScoped<WeavyService>();
builder.Services.AddScoped<UserBlockService>();
builder.Services.AddScoped<JobPostService>();
builder.Services.AddScoped<UserPermissionService>();
builder.Services.AddScoped<JobApplicationService>();
builder.Services.AddScoped<HelperService>();

builder.Services.AddScoped<IValidator<JobPostDto>, JobPostViewModelValidator>();
builder.Services.AddScoped<IValidator<JobApplicationAnswerDto>, JobApplicationAnswerValidator>();

logger.LogInformation($"SessionId: {sessionGuid} - Core Portal Services Configured");

builder.AddCancelableNavigationManager();

logger.LogInformation($"SessionId: {sessionGuid} - Navigation Manager Configured");

ToastService.Icons[ToastLevel.Info] = "fas fa-info";
ToastService.Icons[ToastLevel.Success] = "fas fa-check";
ToastService.Icons[ToastLevel.Warning] = "fas fa-exclamation";
ToastService.Icons[ToastLevel.Error] = "fas fa-times";

logger.LogInformation($"SessionId: {sessionGuid} - Toast Icon Settings Configured");

builder.Services.AddPermissionsRcl();

logger.LogInformation($"SessionId: {sessionGuid} - RCLs Configured");

await builder.Build().RunAsync();

