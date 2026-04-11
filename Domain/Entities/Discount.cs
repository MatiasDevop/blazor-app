namespace Domain.Entities
{
    public class Discount
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public bool IsPercentage { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public PartnerPlan TargetPlan { get; set; }
    }
}
