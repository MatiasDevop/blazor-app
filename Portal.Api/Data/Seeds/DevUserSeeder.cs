using Domain.Entities;
using Enums;
using Microsoft.EntityFrameworkCore;

namespace Portal.Api.Data.Seeds;

public static class DevUserSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        const string devEmail = "dev@cpcc.local";

        var exists = await context.UserProfiles
            .AnyAsync(u => u.Email == devEmail);

        if (exists) return;

        var devUser = new UserProfile
        {
            Id = Guid.NewGuid(),
            Email = devEmail,
            FirstName = "Dev",
            LastName = "User",
            PhoneNumber = "555-0100",
            Phone = "555-0100",
            Mobile = "555-0100",
            ProfileType = ProfileType.Student,
            CreatedAt = DateTime.UtcNow,
        };

        context.UserProfiles.Add(devUser);
        await context.SaveChangesAsync();
    }
}
