using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using ViewModels.Requests.Endpoints.UserProfile;
using ViewModels.Dtos;
using System.Linq;

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

    private static PartialUserProfileDto MapToDto(Domain.Entities.UserProfile userProfile)
    {
        return new PartialUserProfileDto
        {
            Id = userProfile.Id,
            FirstName = userProfile.FirstName,
            LastName = userProfile.LastName,
            Phone = userProfile.PhoneNumber ?? userProfile.Phone ?? string.Empty,
            EmailAddress = userProfile.Email,
            ProfileType = userProfile.ProfileType ?? Enums.ProfileType.Student,
            GenderIdentity = userProfile.GenderIdentity != null ? new SmartCodeDto
            {
                Id = userProfile.GenderIdentity.Id,
                Code = userProfile.GenderIdentity.Code,
                Label = userProfile.GenderIdentity.Label,
                Order = userProfile.GenderIdentity.Order
            } : null,
            SexualIdentity = userProfile.SexualIdentity != null ? new SmartCodeDto
            {
                Id = userProfile.SexualIdentity.Id,
                Code = userProfile.SexualIdentity.Code,
                Label = userProfile.SexualIdentity.Label,
                Order = userProfile.SexualIdentity.Order
            } : null,
            PrimaryLanguage = userProfile.PrimaryLanguage != null ? new SmartCodeDto
            {
                Id = userProfile.PrimaryLanguage.Id,
                Code = userProfile.PrimaryLanguage.Code,
                Label = userProfile.PrimaryLanguage.Label,
                Order = userProfile.PrimaryLanguage.Order
            } : null,
            WorkHistories = new List<WorkHistoryDto>(),
            EducationHistories = new List<EducationHistoryDto>(),
            SocialLinks = new List<SocialLinkDto>(),
            WorkSamples = new List<WorkSampleDto>()
        };
    }
}
