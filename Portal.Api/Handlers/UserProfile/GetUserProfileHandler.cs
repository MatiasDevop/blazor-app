using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using ViewModels.Requests.Endpoints.UserProfile;
using ViewModels.Dtos;

namespace Portal.Api.Handlers.UserProfile;

public class GetUserProfileHandler : IRequestHandler<GetUserProfileRequest, GetUserProfileResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<GetUserProfileHandler> _logger;

    public GetUserProfileHandler(ApplicationDbContext context, ILogger<GetUserProfileHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<GetUserProfileResult> Handle(GetUserProfileRequest request, CancellationToken cancellationToken)
    {
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
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (userProfile == null)
        {
            _logger.LogWarning("User profile {UserId} not found", request.UserId);
            throw new KeyNotFoundException($"User profile with ID {request.UserId} not found");
        }

        var userProfileDto = MapToDto(userProfile);

        _logger.LogInformation("Retrieved user profile {UserId}", request.UserId);

        return new GetUserProfileResult(request.RequestId, userProfileDto);
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
