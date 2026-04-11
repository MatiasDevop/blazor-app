namespace Domain.Entities
{
    public class UserBlock
    {
        public Guid Id { get; set; }
        public Guid BlockerId { get; set; }
        public UserProfile Blocker { get; set; } = null!;
        public Guid BlockedId { get; set; }
        public UserProfile Blocked { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? Reason { get; set; }
        public bool ReportOnly { get; set; }
        public DateTime? DateUnblocked { get; set; }

    }
}
