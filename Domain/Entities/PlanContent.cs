namespace Domain.Entities
{
    public class PlanContent
    {
        public Guid Id { get; set; }
        public Guid PartnerPlanId { get; set; }
        public PartnerPlan PartnerPlan { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public string? Content { get; set; }
    }
}
