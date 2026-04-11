namespace Domain.Entities
{
    public class OrgUserConnection
    {
        public Guid Id { get; set; }
        public Guid CompanyProfileId { get; set; }
        public CompanyProfile CompanyProfile { get; set; } = null!;
        public Guid UserProfileId { get; set; }
        public UserProfile User { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public CompanyClaim Company { get; set; } = null!;
        public SchoolClaim School { get; set; } = null!;
    }
}
