using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Portal.Api.Data;
using Domain.Entities;
using ViewModels.Requests.Endpoints.UserProfile;
using Enums;

namespace Portal.Api.Handlers.UserProfile;

public class RegisterCareerCenterHandler : IRequestHandler<RegisterCareerCenterRequest, RegisterCareerCenterResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<RegisterCareerCenterHandler> _logger;

    public RegisterCareerCenterHandler(ApplicationDbContext context, ILogger<RegisterCareerCenterHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<RegisterCareerCenterResult> Handle(RegisterCareerCenterRequest request, CancellationToken cancellationToken)
    {
        var command = request.Command;

        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            // Validate email uniqueness
            var emailExists = await _context.UserProfiles
                .AnyAsync(u => u.Email == command.EmailAddress, cancellationToken);

            if (emailExists)
            {
                _logger.LogWarning("Career center registration failed: Email {Email} already exists", command.EmailAddress);
                return new RegisterCareerCenterResult(
                    request.RequestId,
                    Guid.Empty,
                    Guid.Empty,
                    command.EmailAddress,
                    false,
                    "Email address is already registered");
            }

            // Create School
            var school = new School
            {
                Id = Guid.NewGuid(),
                Name = command.FirstName + " " + command.LastName, // Temporary, should come from claim
                CreatedAt = DateTime.UtcNow
            };

            if (command.Claim?.School != null)
            {
                school.UniversityName = command.Claim.School.UniversityName ?? school.Name;
                school.CollegeName = command.Claim.School.CollegeName;
                school.Name = school.UniversityName ?? school.CollegeName ?? school.Name;
                school.DisplayName = school.UniversityName ?? school.CollegeName;
            }

            _context.Schools.Add(school);

            // Create UserProfile
            var userProfile = new Domain.Entities.UserProfile
            {
                Id = Guid.NewGuid(),
                Email = command.EmailAddress,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Phone = command.Phone,
                PhoneNumber = command.Phone,
                ProfileType = ProfileType.BusinessAdmin,
                CreatedAt = DateTime.UtcNow
            };

            // Set SmartCode references
            if (command.GenderIdentity != Guid.Empty)
            {
                var genderIdentity = await _context.SmartCodes.FindAsync(new object[] { command.GenderIdentity }, cancellationToken);
                if (genderIdentity != null)
                    userProfile.GenderIdentity = genderIdentity;
            }

            _context.UserProfiles.Add(userProfile);

            // Create Address
            Address? address = null;
            if (command.MailingAddress != null)
            {
                address = new Address
                {
                    Id = Guid.NewGuid(),
                    Line1 = command.MailingAddress.Line1,
                    City = command.MailingAddress.City,
                    ZipCode = command.MailingAddress.ZipCode,
                    PostalCode = command.MailingAddress.ZipCode
                };

                if (command.MailingAddress.State != Guid.Empty)
                {
                    var state = await _context.SmartCodes.FindAsync(new object[] { command.MailingAddress.State }, cancellationToken);
                    if (state != null)
                        address.State = state;
                }

                _context.Addresses.Add(address);
            }

            // Create SchoolClaim
            var schoolClaim = new SchoolClaim
            {
                Id = Guid.NewGuid(),
                SchoolId = school.Id,
                Status = Enum.GetName(ClaimStatus.Pending),
                Email = command.EmailAddress,
                CreatedAt = DateTime.UtcNow,
                Address = address!,
                UserProfile = userProfile
            };

            if (command.Claim != null)
            {
                schoolClaim.Website = command.Claim.Website;
                schoolClaim.CareerCenterName = command.Claim.CareerCenterName;
                schoolClaim.WhoWeAre = command.Claim.WhoWeAre;
                schoolClaim.VideoUrl = command.Claim.VideoUrl;

                // Set institution type if provided
                if (command.Claim.InstitutionType != Guid.Empty)
                {
                    var institutionType = await _context.SmartCodes.FindAsync(
                        new object[] { command.Claim.InstitutionType },
                        cancellationToken);
                    if (institutionType != null)
                        schoolClaim.InstitutionType = institutionType;
                }

                // Set organization size if provided
                if (command.Claim.OrganizationSize != Guid.Empty)
                {
                    var orgSize = await _context.SmartCodes.FindAsync(
                        new object[] { command.Claim.OrganizationSize },
                        cancellationToken);
                    if (orgSize != null)
                        schoolClaim.OrganizationSize = orgSize;
                }
            }

            _context.SchoolClaims.Add(schoolClaim);

            // Create Social Links
            if (command.Claim?.SocialLinks != null && command.Claim.SocialLinks.Any())
            {
                foreach (var linkDto in command.Claim.SocialLinks)
                {
                    var socialLink = new SocialLink
                    {
                        Id = Guid.NewGuid(),
                        Url = linkDto.Url
                    };
                    _context.SocialLinks.Add(socialLink);
                    schoolClaim.SocialLinks.Add(socialLink);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            _logger.LogInformation("Career center user profile and school created successfully: UserId: {UserId}, SchoolId: {SchoolId}, Email: {Email}",
                userProfile.Id, school.Id, userProfile.Email);

            return new RegisterCareerCenterResult(
                request.RequestId,
                userProfile.Id,
                school.Id,
                userProfile.Email,
                true,
                "Career center registered successfully");
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            _logger.LogError(ex, "Error registering career center with email {Email}", command.EmailAddress);
            throw;
        }
    }
}
