using ViewModels.Dtos;

namespace ViewModels.Commands
{
    public class RegisterCareerCenterCommand : RegisterOrganizationCommand
    {
        public SchoolClaimDto Claim { get; set; }
    }
}