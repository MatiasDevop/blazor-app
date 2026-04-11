namespace Domain.Entities
{
    public class PlanContentSection
    {
        public Guid Id { get; set; }
        public Guid PlanContentId { get; set; }
        public PlanContent PlanContent { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public string? Content { get; set; }
    }
}
