using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using ViewModels.Dtos;
using ViewModels.Requests.Endpoints.UserProfile;

namespace Portal.Api.Handlers.UserProfile;

public class GetCurrentUserProfileHandler : IRequestHandler<GetCurrentUserProfileRequest, GetCurrentUserProfileResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<GetCurrentUserProfileHandler> _logger;

    public GetCurrentUserProfileHandler(ApplicationDbContext context, ILogger<GetCurrentUserProfileHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<GetCurrentUserProfileResult> Handle(GetCurrentUserProfileRequest request, CancellationToken cancellationToken)
    {
        var email = request.Email.Trim().ToLowerInvariant();

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
            .FirstOrDefaultAsync(u => u.Email.ToLower() == email, cancellationToken);

        if (userProfile == null)
        {
            _logger.LogInformation("No profile found for authenticated user {Email}", request.Email);
            return new GetCurrentUserProfileResult(request.RequestId, null, false);
        }

        var dto = MapToFullDto(userProfile);

        _logger.LogInformation("Retrieved current user profile for {Email}", request.Email);
        return new GetCurrentUserProfileResult(request.RequestId, dto, true);
    }

    private static FullUserProfileDto MapToFullDto(Domain.Entities.UserProfile u)
    {
        var address = u.Addresses.FirstOrDefault();

        return new FullUserProfileDto
        {
            Id = u.Id,
            FirstName = u.FirstName,
            LastName = u.LastName,
            EmailAddress = u.Email,
            Phone = u.PhoneNumber ?? u.Phone ?? string.Empty,
            ProfileType = u.ProfileType ?? Enums.ProfileType.Student,
            GenderIdentity = MapSmartCode(u.GenderIdentity),
            SexualIdentity = MapSmartCode(u.SexualIdentity),
            Pronouns = MapSmartCode(u.PrimaryLanguage),
            MailingAddress = MapAddress(address),
            WorkHistories = new List<WorkHistoryDto>(),
            EducationHistories = new List<EducationHistoryDto>(),
            SocialLinks = new List<SocialLinkDto>(),
            WorkSamples = new List<WorkSampleDto>(),
            SchoolClaims = u.SchoolClaims.Select(s => s.Id).ToList(),
            CompanyClaims = u.CompanyClaims.Select(c => c.Id).ToList(),
            Favorites = new List<UserFavoriteDto>(),
            OrgConnections = new List<OrgUserConnectionDto>(),
            Connections = new List<UserConnectionDto>(),
            Blocks = new List<Guid>(),
        };
    }

    private static SmartCodeDto? MapSmartCode(Domain.Entities.SmartCode? code)
    {
        if (code == null) return null;
        return new SmartCodeDto
        {
            Id = code.Id,
            Code = code.Code ?? string.Empty,
            Label = code.Label,
            Order = code.Order
        };
    }

    private static FullAddressDto? MapAddress(Domain.Entities.Address? address)
    {
        if (address == null) return null;
        return new FullAddressDto
        {
            Line1 = address.Line1 ?? string.Empty,
            City = address.City ?? string.Empty,
            ZipCode = address.ZipCode ?? address.PostalCode ?? string.Empty,
            State = MapSmartCode(address.State),
        };
    }
}
