using Enums;

namespace ViewModels.Dtos
{
    public class FullCompanyDto : FullOrgDto
    {
        public CompanyDto CompanyProfile { get; set; }
        public string Description { get; set; }
        public Dictionary<string, List<SmartCodeDto>> MultiSelections { get; set; }
        public List<SocialLinkDto> SocialLinks { get; set; }
        public List<PartialCompanyDocumentDto> Documents { get; set; }
        public string AffinityGroupName { get; set; }
        public string AffinityGroupDescription { get; set; }
        public string AffinityGroupWebsite { get; set; }
        public WorkAuthorizationType WorkAuthorization { get; set; }
        public List<CompanyWorkAuthorizationDto> AcceptedWorkAuthorizations { get; set; }
        public string WorkAuthorizationOther { get; set; }
        public List<EducationFocusDto> Majors { get; set; }
        public Guid? PartnerPlanId { get; set; }
        public bool ClaimIsActive { get; set; }

    }
}