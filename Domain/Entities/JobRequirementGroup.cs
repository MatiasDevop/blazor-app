namespace Domain.Entities
{
    public class JobRequirementGroup
    {
        public Guid Id { get; set; }
        public Guid JobPostId { get; set; }
        public JobPost JobPost { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public string Label { get; set; }
        public int Order { get; set; }
        public ICollection<JobRequirement> Requirements { get; set; } = new List<JobRequirement>();
    }
}
