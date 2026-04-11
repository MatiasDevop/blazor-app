using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using Portal.Api.Data.Seeds;

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

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
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
}
app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();
