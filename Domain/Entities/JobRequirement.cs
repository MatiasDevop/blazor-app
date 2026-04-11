namespace Domain.Entities
{
    public class JobRequirement
    {
        public Guid Id { get; set; }
        public Guid JobPostId { get; set; }
        public JobPost JobPost { get; set; } = null!;

        public string Name { get; set; } = string.Empty;
        public string? Value { get; set; }
        public string Text { get; set; }
        public JobRequirementGroup Group { get; set; }
    }
}
