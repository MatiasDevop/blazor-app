namespace Domain.Entities
{
    public class UserConnection
    {
        public Guid Id { get; set; }
        public Guid RequesterId { get; set; }
        public UserProfile Requester { get; set; } = null!;
        public Guid RecipientId { get; set; }
        public UserProfile Recipient { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? Status { get; set; }
        public DateTime? DateApproved { get; set; }
        public UserProfile Approver { get; set; }
        public UserProfile Initiator { get; set; }
    }
}
