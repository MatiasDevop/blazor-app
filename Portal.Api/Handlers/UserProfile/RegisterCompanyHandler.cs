using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Portal.Api.Data;
using Domain.Entities;
using ViewModels.Requests.Endpoints.UserProfile;
using Enums;

namespace Portal.Api.Handlers.UserProfile;

public class RegisterCompanyHandler : IRequestHandler<RegisterCompanyRequest, RegisterCompanyResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<RegisterCompanyHandler> _logger;

    public RegisterCompanyHandler(ApplicationDbContext context, ILogger<RegisterCompanyHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<RegisterCompanyResult> Handle(RegisterCompanyRequest request, CancellationToken cancellationToken)
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
                _logger.LogWarning("Company registration failed: Email {Email} already exists", command.EmailAddress);
                return new RegisterCompanyResult(
                    request.RequestId,
                    Guid.Empty,
                    Guid.Empty,
                    command.EmailAddress,
                    false,
                    "Email address is already registered");
            }

            // Create CompanyProfile
            var companyProfile = new CompanyProfile
            {
                Id = Guid.NewGuid(),
                Name = command.FirstName + " " + command.LastName, // Temporary, should come from claim
                CreatedAt = DateTime.UtcNow
            };

            _context.CompanyProfiles.Add(companyProfile);

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

            // Create CompanyClaim
            var companyClaim = new CompanyClaim
            {
                Id = Guid.NewGuid(),
                CompanyProfileId = companyProfile.Id,
                UserProfileId = userProfile.Id,
                Status = ClaimStatus.Pending,
                Email = command.EmailAddress,
                AddressId = address?.Id
            };

            if (command.Claim != null)
            {
                companyClaim.Website = command.Claim.Website;
                companyClaim.Description = command.Claim.Description;
                companyClaim.VideoUrl = command.Claim.VideoUrl;
                companyClaim.AffinityGroupName = command.Claim.AffinityGroupName;
                companyClaim.AffinityGroupDescription = command.Claim.AffinityGroupDescription;
                companyClaim.AffinityGroupWebsite = command.Claim.AffinityGroupWebsite;
                companyClaim.WorkAuthorization = command.Claim.WorkAuthorizationType;
                companyClaim.WorkAuthorizationOther = command.Claim.WorkAuthorizationOther;

                // Set organization size if provided
                if (command.Claim.OrganizationSize != Guid.Empty)
                {
                    var orgSize = await _context.SmartCodes.FindAsync(
                        new object[] { command.Claim.OrganizationSize },
                        cancellationToken);
                    if (orgSize != null)
                        companyClaim.OrganizationSize = orgSize;
                }

                // Update company profile with claim data
                if (command.Claim.Company != null)
                {
                    companyProfile.Name = command.Claim.Company.Name ?? companyProfile.Name;
                }

                companyProfile.Description = command.Claim.Description;
                companyProfile.WebsiteUrl = command.Claim.Website;
            }

            _context.CompanyClaims.Add(companyClaim);

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
                    companyClaim.SocialLinks.Add(socialLink);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            _logger.LogInformation("Company user profile and company created successfully: UserId: {UserId}, CompanyId: {CompanyId}, Email: {Email}",
                userProfile.Id, companyProfile.Id, userProfile.Email);

            return new RegisterCompanyResult(
                request.RequestId,
                userProfile.Id,
                companyProfile.Id,
                userProfile.Email,
                true,
                "Company registered successfully");
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            _logger.LogError(ex, "Error registering company with email {Email}", command.EmailAddress);
            throw;
        }
    }
}
