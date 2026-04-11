using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Portal.Api.Data.Seeds;

public static class SmartTypesSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.SmartTypes.AnyAsync())
        {
            // Data already seeded
            return;
        }

        var smartTypes = new List<SmartType>();
        var smartCodes = new List<SmartCode>();

        // 1. US States
        var statesType = new SmartType { Id = Guid.NewGuid(), Name = "State", Category = "Geography" };
        smartTypes.Add(statesType);

        var usStates = new Dictionary<string, string>
        {
            { "AL", "Alabama" }, { "AK", "Alaska" }, { "AZ", "Arizona" }, { "AR", "Arkansas" },
            { "CA", "California" }, { "CO", "Colorado" }, { "CT", "Connecticut" }, { "DE", "Delaware" },
            { "FL", "Florida" }, { "GA", "Georgia" }, { "HI", "Hawaii" }, { "ID", "Idaho" },
            { "IL", "Illinois" }, { "IN", "Indiana" }, { "IA", "Iowa" }, { "KS", "Kansas" },
            { "KY", "Kentucky" }, { "LA", "Louisiana" }, { "ME", "Maine" }, { "MD", "Maryland" },
            { "MA", "Massachusetts" }, { "MI", "Michigan" }, { "MN", "Minnesota" }, { "MS", "Mississippi" },
            { "MO", "Missouri" }, { "MT", "Montana" }, { "NE", "Nebraska" }, { "NV", "Nevada" },
            { "NH", "New Hampshire" }, { "NJ", "New Jersey" }, { "NM", "New Mexico" }, { "NY", "New York" },
            { "NC", "North Carolina" }, { "ND", "North Dakota" }, { "OH", "Ohio" }, { "OK", "Oklahoma" },
            { "OR", "Oregon" }, { "PA", "Pennsylvania" }, { "RI", "Rhode Island" }, { "SC", "South Carolina" },
            { "SD", "South Dakota" }, { "TN", "Tennessee" }, { "TX", "Texas" }, { "UT", "Utah" },
            { "VT", "Vermont" }, { "VA", "Virginia" }, { "WA", "Washington" }, { "WV", "West Virginia" },
            { "WI", "Wisconsin" }, { "WY", "Wyoming" }, { "DC", "District of Columbia" }
        };

        var order = 1;
        foreach (var (code, name) in usStates)
        {
            smartCodes.Add(new SmartCode
            {
                Id = Guid.NewGuid(),
                SmartTypeId = statesType.Id,
                Code = code,
                Value = code,
                Label = name,
                Order = order++,
                Description = name,
                IsCustom = false
            });
        }

        // 2. Gender Identity
        var genderIdentityType = new SmartType { Id = Guid.NewGuid(), Name = "GenderIdentity", Category = "Demographics" };
        smartTypes.Add(genderIdentityType);

        var genderIdentities = new[]
        {
            "Woman", "Man", "Non-binary", "Genderqueer", "Genderfluid", "Agender",
            "Transgender", "Two-Spirit", "Other", "Prefer not to say"
        };

        order = 1;
        foreach (var identity in genderIdentities)
        {
            smartCodes.Add(new SmartCode
            {
                Id = Guid.NewGuid(),
                SmartTypeId = genderIdentityType.Id,
                Code = identity.ToUpper().Replace(" ", "_"),
                Value = identity,
                Label = identity,
                Order = order++,
                Description = identity,
                IsCustom = false
            });
        }

        // 3. Sexual Orientation
        var sexualOrientationType = new SmartType { Id = Guid.NewGuid(), Name = "SexualOrientation", Category = "Demographics" };
        smartTypes.Add(sexualOrientationType);

        var orientations = new[]
        {
            "Lesbian", "Gay", "Bisexual", "Pansexual", "Asexual", "Queer",
            "Questioning", "Heterosexual", "Other", "Prefer not to say"
        };

        order = 1;
        foreach (var orientation in orientations)
        {
            smartCodes.Add(new SmartCode
            {
                Id = Guid.NewGuid(),
                SmartTypeId = sexualOrientationType.Id,
                Code = orientation.ToUpper().Replace(" ", "_"),
                Value = orientation,
                Label = orientation,
                Order = order++,
                Description = orientation,
                IsCustom = false
            });
        }

        // 4. Primary Language
        var languageType = new SmartType { Id = Guid.NewGuid(), Name = "PrimaryLanguage", Category = "Communication" };
        smartTypes.Add(languageType);

        var languages = new[]
        {
            "English", "Spanish", "French", "German", "Chinese (Mandarin)",
            "Chinese (Cantonese)", "Japanese", "Korean", "Arabic", "Portuguese",
            "Russian", "Italian", "Hindi", "Vietnamese", "Tagalog", "Other"
        };

        order = 1;
        foreach (var language in languages)
        {
            smartCodes.Add(new SmartCode
            {
                Id = Guid.NewGuid(),
                SmartTypeId = languageType.Id,
                Code = language.ToUpper().Replace(" ", "_").Replace("(", "").Replace(")", ""),
                Value = language,
                Label = language,
                Order = order++,
                Description = language,
                IsCustom = false
            });
        }

        // 5. Race/Ethnicity
        var raceEthnicityType = new SmartType { Id = Guid.NewGuid(), Name = "RaceEthnicity", Category = "Demographics" };
        smartTypes.Add(raceEthnicityType);

        var races = new[]
        {
            "American Indian or Alaska Native", "Asian", "Black or African American",
            "Hispanic or Latino", "Native Hawaiian or Other Pacific Islander",
            "White", "Two or More Races", "Other", "Prefer not to say"
        };

        order = 1;
        foreach (var race in races)
        {
            smartCodes.Add(new SmartCode
            {
                Id = Guid.NewGuid(),
                SmartTypeId = raceEthnicityType.Id,
                Code = race.ToUpper().Replace(" ", "_"),
                Value = race,
                Label = race,
                Order = order++,
                Description = race,
                IsCustom = false
            });
        }

        // 6. Pronouns
        var pronounsType = new SmartType { Id = Guid.NewGuid(), Name = "Pronouns", Category = "Demographics" };
        smartTypes.Add(pronounsType);

        var pronouns = new[]
        {
            "He/Him/His", "She/Her/Hers", "They/Them/Theirs", "Ze/Zir/Zirs",
            "Xe/Xem/Xyrs", "Other", "Prefer not to say"
        };

        order = 1;
        foreach (var pronoun in pronouns)
        {
            smartCodes.Add(new SmartCode
            {
                Id = Guid.NewGuid(),
                SmartTypeId = pronounsType.Id,
                Code = pronoun.ToUpper().Replace("/", "_"),
                Value = pronoun,
                Label = pronoun,
                Order = order++,
                Description = pronoun,
                IsCustom = false
            });
        }

        // 7. Organization Size
        var orgSizeType = new SmartType { Id = Guid.NewGuid(), Name = "OrganizationSize", Category = "Business" };
        smartTypes.Add(orgSizeType);

        var orgSizes = new[]
        {
            "1-10 employees", "11-50 employees", "51-200 employees", "201-500 employees",
            "501-1000 employees", "1001-5000 employees", "5001-10000 employees", "10000+ employees"
        };

        order = 1;
        foreach (var size in orgSizes)
        {
            smartCodes.Add(new SmartCode
            {
                Id = Guid.NewGuid(),
                SmartTypeId = orgSizeType.Id,
                Code = size.Replace(" ", "_").Replace("-", "_").Replace("+", "PLUS"),
                Value = size,
                Label = size,
                Order = order++,
                Description = size,
                IsCustom = false
            });
        }

        // 8. Industry
        var industryType = new SmartType { Id = Guid.NewGuid(), Name = "Industry", Category = "Business" };
        smartTypes.Add(industryType);

        var industries = new[]
        {
            "Technology", "Healthcare", "Finance", "Education", "Retail", "Manufacturing",
            "Hospitality", "Real Estate", "Media & Entertainment", "Legal", "Nonprofit",
            "Government", "Consulting", "Transportation", "Energy", "Agriculture",
            "Construction", "Telecommunications", "Other"
        };

        order = 1;
        foreach (var industry in industries)
        {
            smartCodes.Add(new SmartCode
            {
                Id = Guid.NewGuid(),
                SmartTypeId = industryType.Id,
                Code = industry.ToUpper().Replace(" ", "_").Replace("&", "AND"),
                Value = industry,
                Label = industry,
                Order = order++,
                Description = industry,
                IsCustom = false
            });
        }

        // 9. Degree Level
        var degreeLevelType = new SmartType { Id = Guid.NewGuid(), Name = "DegreeLevel", Category = "Education" };
        smartTypes.Add(degreeLevelType);

        var degreeLevels = new[]
        {
            "High School Diploma", "Associate's Degree", "Bachelor's Degree",
            "Master's Degree", "Doctorate (PhD)", "Professional Degree (JD, MD, etc.)",
            "Certificate Program", "Some College (No Degree)", "Other"
        };

        order = 1;
        foreach (var degree in degreeLevels)
        {
            smartCodes.Add(new SmartCode
            {
                Id = Guid.NewGuid(),
                SmartTypeId = degreeLevelType.Id,
                Code = degree.ToUpper().Replace(" ", "_").Replace("'", "").Replace("(", "").Replace(")", "").Replace(",", ""),
                Value = degree,
                Label = degree,
                Order = order++,
                Description = degree,
                IsCustom = false
            });
        }

        // 10. Skills (Common Technical & Professional Skills)
        var skillsType = new SmartType { Id = Guid.NewGuid(), Name = "Skills", Category = "Professional" };
        smartTypes.Add(skillsType);

        var skills = new[]
        {
            "Project Management", "Data Analysis", "Software Development", "Marketing",
            "Sales", "Customer Service", "Leadership", "Communication", "Problem Solving",
            "Teamwork", "Time Management", "Critical Thinking", "Adaptability",
            "Research", "Writing", "Public Speaking", "Design", "Financial Analysis"
        };

        order = 1;
        foreach (var skill in skills)
        {
            smartCodes.Add(new SmartCode
            {
                Id = Guid.NewGuid(),
                SmartTypeId = skillsType.Id,
                Code = skill.ToUpper().Replace(" ", "_"),
                Value = skill,
                Label = skill,
                Order = order++,
                Description = skill,
                IsCustom = false
            });
        }

        // Add all to database
        await context.SmartTypes.AddRangeAsync(smartTypes);
        await context.SmartCodes.AddRangeAsync(smartCodes);
        await context.SaveChangesAsync();

        Console.WriteLine($"✓ Seeded {smartTypes.Count} SmartTypes");
        Console.WriteLine($"✓ Seeded {smartCodes.Count} SmartCodes");
    }
}
