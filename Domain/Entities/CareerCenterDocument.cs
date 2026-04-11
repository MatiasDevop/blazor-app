namespace Domain.Entities
{
    public class CareerCenterDocument
    {
        public Guid Id { get; set; }
        public Guid SchoolId { get; set; }
        public School School { get; set; } = null!;
        public string Description { get; set; }
        public byte[] File { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Url { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
