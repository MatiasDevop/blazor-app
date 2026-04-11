namespace Domain.Entities
{
    public class JobApplication
    {
        public Guid Id { get; set; }
        public Guid JobPostId { get; set; }
        public JobPost JobPost { get; set; } = null!;

        public Guid UserProfileId { get; set; }
        public UserProfile Applicant { get; set; } = null!;

        public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
        public string? Status { get; set; }
        public DateTime DateApplied { get; set; }
        public DateTime DateReviewed { get; set; }
        public string? CoverLetter { get; set; }
        public ICollection<JobApplicationAnswer> Answers { get; set; } = new List<JobApplicationAnswer>();

    }
}
