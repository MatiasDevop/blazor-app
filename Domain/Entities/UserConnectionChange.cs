namespace Domain.Entities
{
    public class UserConnectionChange
    {
        public Guid Id { get; set; }
        public Guid UserConnectionId { get; set; }
        public UserConnection UserConnection { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? ChangeType { get; set; }
        public string? Notes { get; set; }
    }
}
