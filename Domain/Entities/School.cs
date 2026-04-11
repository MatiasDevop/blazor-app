namespace Domain.Entities
{
    public class School
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public SmartCode State { get; set; }
        public SchoolClaim ActiveClaim { get; set; }
        public string UniversityName { get; set; } = string.Empty;
        public string CollegeName { get; set; }
        public string ZipCode { get; set; }
        public string DisplayName { get; set; }

    }
}
