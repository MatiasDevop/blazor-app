namespace Domain.Entities
{
    public class UserOrganization
    {
        public Guid Id { get; set; }

        public Guid UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; } = null!;

        public Guid CompanyProfileId { get; set; }
        public CompanyProfile CompanyProfile { get; set; } = null!;

        public bool IsAccounting { get; set; }
        public bool IsBilling { get; set; }
        public bool IsClaimHolder { get; set; }
        public bool IsEventsManager { get; set; }
        public bool IsUserManager { get; set; }
        public bool IsRecruiter { get; set; }
        public bool IsTechnical { get; set; }
        public bool IsAccountOwner { get; set; }
        public bool IsJobManager { get; set; }
    }
}
