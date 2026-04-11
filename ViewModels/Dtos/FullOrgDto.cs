
using ViewModels.ViewModels;

namespace ViewModels.Dtos
{
    public class FullOrgDto
    {
        public Guid Id { get; set; }
        public Guid ClaimOwnerId { get; set; }
        public SmartCodeDto OrganizationSize { get; set; }
        public FullAddressDto Address { get; set; }
        public string Website { get; set; }
        public string VideoUrl { get; set; }
        public List<EmployeeVm> Employees { get; set; }
        public string Email { get; set; }
    }
}