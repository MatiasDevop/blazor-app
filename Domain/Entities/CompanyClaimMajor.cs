namespace Domain.Entities
{
    public class CompanyClaimMajor
    {
        public Guid Id { get; set; }
        public Guid CompanyClaimId { get; set; }
        public CompanyClaim CompanyClaim { get; set; } = null!;
        public Guid SmartCodeId { get; set; }
        public SmartCode SmartCode { get; set; } = null!;
        public EducationFocus EducationFocus { get; set; }

    }
}
