namespace Domain.Entities
{
    public class UserFavorite
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; } = null!;
        public Guid JobPostId { get; set; }
        public JobPost JobPost { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
