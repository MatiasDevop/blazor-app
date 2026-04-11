namespace Domain.Entities
{
    public class CompanyClaimWorkAuthorization
    {
        public Guid Id { get; set; }
        public Guid CompanyClaimId { get; set; }
        public CompanyClaim CompanyClaim { get; set; } = null!;
        public Guid SmartCodeId { get; set; }
        public SmartCode SmartCode { get; set; } = null!;
    }
}
