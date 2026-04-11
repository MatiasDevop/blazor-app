using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using ViewModels.Requests.Endpoints.UserProfile;
using ViewModels.Dtos;

namespace Portal.Api.Handlers.UserProfile;

public class GetUserForEmailHandler : IRequestHandler<GetUserForEmailRequest, GetUserForEmailResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<GetUserForEmailHandler> _logger;

    public GetUserForEmailHandler(ApplicationDbContext context, ILogger<GetUserForEmailHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<GetUserForEmailResult> Handle(GetUserForEmailRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Email))
        {
            _logger.LogWarning("GetUserForEmail called with empty email");
            throw new ArgumentException("Email cannot be null or empty", nameof(request.Email));
        }

        var normalizedEmail = request.Email.Trim().ToLowerInvariant();

        var userProfile = await _context.UserProfiles
            .Include(u => u.Addresses)
                .ThenInclude(a => a.State)
            .Include(u => u.WorkHistories)
            .Include(u => u.EducationHistories)
            .Include(u => u.SocialLinks)
            .Include(u => u.WorkSamples)
            .Include(u => u.GenderIdentity)
            .Include(u => u.SexualIdentity)
            .Include(u => u.PrimaryLanguage)
            .Include(u => u.CompanyClaims)
            .Include(u => u.SchoolClaims)
            .FirstOrDefaultAsync(u => u.Email.ToLower() == normalizedEmail, cancellationToken);

        if (userProfile == null)
        {
            _logger.LogInformation("User profile not found for email {Email}", request.Email);
            return new GetUserForEmailResult(request.RequestId, null, false);
        }

        var userProfileDto = MapToDto(userProfile);

        _logger.LogInformation("Retrieved user profile for email {Email}, UserId: {UserId}",
            request.Email, userProfile.Id);

        return new GetUserForEmailResult(request.RequestId, userProfileDto, true);
    }

    private static UserProfileDto MapToDto(Domain.Entities.UserProfile userProfile)
    {
        var address = userProfile.Addresses.FirstOrDefault();

        return new UserProfileDto
        {
            Id = userProfile.Id,
            FirstName = userProfile.FirstName,
            LastName = userProfile.LastName,
            Phone = userProfile.PhoneNumber ?? userProfile.Phone ?? string.Empty,
            EmailAddress = userProfile.Email,
            ProfileType = userProfile.ProfileType,
            GenderIdentity = userProfile.GenderIdentity?.Id ?? Guid.Empty,
            SexualIdentity = userProfile.SexualIdentity?.Id ?? Guid.Empty,
            Pronouns = userProfile.PrimaryLanguage?.Id ?? Guid.Empty,
            MailingAddress = address != null ? new AddressDto
            {
                Line1 = address.Line1,
                City = address.City,
                State = address.State?.Id ?? Guid.Empty,
                ZipCode = address.ZipCode ?? address.PostalCode ?? string.Empty
            } : null
        };
    }
}
