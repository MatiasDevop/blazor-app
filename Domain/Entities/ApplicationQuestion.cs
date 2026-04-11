
namespace Domain.Entities
{
    public class ApplicationQuestion
    {
        public Guid Id { get; set; }
        public Guid JobPostId { get; set; }
        public string Text { get; set; }
        public JobPost JobPost { get; set; } = null!;
        public string Question { get; set; } = string.Empty;
        public bool IsRequired { get; set; }
        public string? Type { get; set; }
        public ICollection<JobApplicationAnswer> Answers { get; set; }
    }
}
