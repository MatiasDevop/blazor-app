namespace Domain.Entities
{
    public class SocialLink
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; } = null!;
        public string Platform { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
