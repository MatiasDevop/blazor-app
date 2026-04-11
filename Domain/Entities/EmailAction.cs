namespace Domain.Entities
{
    public class EmailAction
    {
        public Guid Id { get; set; }
        public string Template { get; set; } = string.Empty;
        public Guid? UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
