using Enums;

namespace Domain.Entities
{
    public class WorkSample
    {
        public Guid Id { get; set; }
        public WorkSampleType Type { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Url { get; set; }

        public Guid UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
