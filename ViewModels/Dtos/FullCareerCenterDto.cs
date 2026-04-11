
namespace ViewModels.Dtos
{
    public class FullCareerCenterDto : FullOrgDto
    {
        public string CareerCenterName { get; set; }
        public SchoolDto School { get; set; }
        public SmartCodeDto InstitutionType { get; set; }
        public string WhoWeAre { get; set; }
        public List<PartialCareerCenterDocumentDto> Documents { get; set; }
        public List<SocialLinkDto> SocialLinks { get; set; }
        public Guid? PartnerPlanId { get; set; }
    }
}