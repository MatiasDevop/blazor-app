namespace Domain.Entities
{
    public class PlanPrice
    {
        public Guid Id { get; set; }
        public Guid PartnerPlanId { get; set; }
        public PartnerPlan PartnerPlan { get; set; } = null!;
        public string Interval { get; set; } = string.Empty; // monthly, yearly
        public decimal Price { get; set; }
        public bool ForRenewOnly { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
