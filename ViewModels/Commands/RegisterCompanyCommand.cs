using ViewModels.Dtos;

namespace ViewModels.Commands
{
    public class RegisterCompanyCommand : RegisterOrganizationCommand
    {
        public CompanyClaimDto Claim { get; set; }
    }
}