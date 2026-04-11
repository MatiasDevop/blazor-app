namespace Domain.Entities
{
    public class PlanBenefit
    {
        public Guid Id { get; set; }
        public Guid PartnerPlanId { get; set; }
        public PartnerPlan PartnerPlan { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
