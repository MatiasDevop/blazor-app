using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Portal.Api.Data;
using Portal.Api.Data.Seeds;
using Portal.Api.Middleware;
using Portal.Api.Filters;
using Scalar.AspNetCore;
using System.Reflection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure PostgreSQL Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        npgsqlOptions => npgsqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorCodesToAdd: null)));

// Register MediatR for CQRS pattern
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Configure JWT Authentication with Auth0
var domain = builder.Configuration["Auth0:Domain"];
var audience = builder.Configuration["Auth0:Audience"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = $"https://{domain}/";
        options.Audience = audience;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            NameClaimType = ClaimTypes.NameIdentifier,
            ValidateIssuer = true,
            ValidIssuer = $"https://{domain}/",
            ValidateAudience = true,
            ValidAudience = audience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

// Configure Authorization Policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireStudentRole", policy =>
        policy.RequireClaim("ProfileType", "Student"));

    options.AddPolicy("RequireRecruiterRole", policy =>
        policy.RequireClaim("ProfileType", "BusinessAdmin"));

    options.AddPolicy("RequireCareerCenterRole", policy =>
        policy.RequireClaim("ProfileType", "BusinessAdmin"));

    options.AddPolicy("RequireAdminRole", policy =>
        policy.RequireClaim("role", "Admin"));
});

// Add model validation filter
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidateModelStateFilter>();
});

// Add Swagger/OpenAPI with Scalar UI
builder.Services.AddOpenApi();

builder.Services.AddCors(b => b.AddDefaultPolicy(p => p.WithOrigins("https://localhost:5085").AllowAnyHeader().AllowAnyMethod()));
var app = builder.Build();

// Seed database in development
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    try
    {
        // Ensure database is created and migrations are applied
        await context.Database.MigrateAsync();

        // Seed reference data
        await SmartTypesSeeder.SeedAsync(context);

        Console.WriteLine("✓ Database seeding completed successfully");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"✗ Error seeding database: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "Portal Career Center API";
        options.Theme = ScalarTheme.Purple;
        options.ShowSidebar = true;
    });
}

// Global exception handling middleware
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();
