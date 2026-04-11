namespace Domain.Entities
{
    public class PotentialConnection
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; } = null!;
        public Guid TargetUserProfileId { get; set; }
        public UserProfile TargetUserProfile { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public UserProfile Match { get; set; } = null!;
    }
}
