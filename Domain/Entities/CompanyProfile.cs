namespace Domain.Entities
{
    public class CompanyProfile
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? LogoUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>();
        public CompanyClaim ActiveClaim { get; set; } = new();
    }
}
