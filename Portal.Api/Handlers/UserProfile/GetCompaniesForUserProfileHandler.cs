using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using ViewModels.Dtos;
using ViewModels.Requests.Endpoints.UserProfile;

namespace Portal.Api.Handlers.UserProfile;

public class GetCompaniesForUserProfileHandler : IRequestHandler<GetCompaniesForUserProfileRequest, GetCompaniesForUserProfileResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<GetCompaniesForUserProfileHandler> _logger;

    public GetCompaniesForUserProfileHandler(ApplicationDbContext context, ILogger<GetCompaniesForUserProfileHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<GetCompaniesForUserProfileResult> Handle(GetCompaniesForUserProfileRequest request, CancellationToken cancellationToken)
    {
        var email = request.Email.Trim().ToLowerInvariant();

        var userProfile = await _context.UserProfiles
            .Include(u => u.CompanyClaims)
                .ThenInclude(c => c.CompanyProfile)
            .Include(u => u.SchoolClaims)
                .ThenInclude(s => s.School)
            .FirstOrDefaultAsync(u => u.Email.ToLower() == email, cancellationToken);

        if (userProfile == null)
        {
            _logger.LogInformation("No profile found for {Email} when loading assigned orgs", request.Email);
            return new GetCompaniesForUserProfileResult(request.RequestId, Enumerable.Empty<CompanyClaimDto>(), Enumerable.Empty<SchoolClaimDto>());
        }

        var companyClaims = userProfile.CompanyClaims
            .Select(c => new CompanyClaimDto
            {
                Id = c.Id,
                Company = c.CompanyProfile != null ? new CompanyProfileDto
                {
                    Id = c.CompanyProfile.Id,
                    Name = c.CompanyProfile.Name,
                    ActiveClaimId = c.Id,
                } : null,
                Majors = new List<EducationFocusDto>(),
                MultiSelections = new Dictionary<string, List<SmartCodeDto>>(),
                AcceptedWorkAuthorizations = new List<CompanyWorkAuthorizationDto>(),
            })
            .ToList();

        var schoolClaims = userProfile.SchoolClaims
            .Select(s => new SchoolClaimDto
            {
                Id = s.Id,
                CareerCenterName = s.CareerCenterName ?? s.School?.Name ?? string.Empty,
                WhoWeAre = s.WhoWeAre ?? string.Empty,
                School = s.School != null ? new SchoolDto
                {
                    Id = s.School.Id,
                    UniversityName = s.School.UniversityName ?? s.School.Name,
                    CollegeName = s.School.CollegeName ?? string.Empty,
                    ActiveClaimId = s.Id,
                } : null,
                Documents = new Dictionary<Enums.CareerCenterDocumentType, CareerCenterDocumentDto>(),
            })
            .ToList();

        return new GetCompaniesForUserProfileResult(request.RequestId, companyClaims, schoolClaims);
    }
}
