using Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using ViewModels.Requests.Endpoints.UserProfile;
using ViewModels.ViewModels;

namespace Portal.Api.Handlers.UserProfile;

public class GetEmployeesHandler : IRequestHandler<GetEmployeesRequest, GetEmployeesResult>
{
    private readonly ApplicationDbContext _context;

    public GetEmployeesHandler(ApplicationDbContext context) => _context = context;

    public async Task<GetEmployeesResult> Handle(GetEmployeesRequest request, CancellationToken cancellationToken)
    {
        var employees = await _context.UserProfiles
            .Where(u => u.ProfileType == ProfileType.Mentor)
            .OrderByDescending(u => u.CreatedAt)
            .Take(request.Count)
            .Select(u => new UserLabelVm
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                ProfileType = u.ProfileType ?? ProfileType.Mentor,
            })
            .ToListAsync(cancellationToken);

        return new GetEmployeesResult(request.RequestId, employees);
    }
}
