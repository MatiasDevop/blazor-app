namespace Domain.Entities
{
    public class JobBenefit
    {
        public Guid Id { get; set; }
        public Guid JobPostId { get; set; }
        public JobPost JobPost { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Text { get; set; }
    }
}
