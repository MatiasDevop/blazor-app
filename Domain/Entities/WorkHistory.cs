namespace Domain.Entities
{
    public class WorkHistory
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; } = null!;
        public string? CompanyName { get; set; }
        public string? JobTitle { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public CompanyProfile Company { get; set; }
        public School CareerCenter { get; set; }
    }
}
