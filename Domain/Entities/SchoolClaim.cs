namespace Domain.Entities
{
    public class SchoolClaim
    {
        public Guid Id { get; set; }
        public Guid SchoolId { get; set; }
        public School School { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? Status { get; set; }
        public Address Address { get; set; }
        public UserProfile UserProfile { get; set; }
        public ICollection<SocialLink> SocialLinks { get; set; }
        public ICollection<CareerCenterDocument> Documents { get; set; }
        public ICollection<PartnershipSubscription> Subscriptions { get; set; }
        public ICollection<OrgUserConnection> UserConnections { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public byte[] Logo { get; set; }
        public SmartCode InstitutionType { get; set; }
        public SmartCode OrganizationSize { get; set; }
        public string CareerCenterName { get; set; }
        public string WhoWeAre { get; set; }
        public string VideoUrl { get; set; }
    }
}
