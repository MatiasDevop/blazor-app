namespace Domain.Entities
{
    public class PartnerPlan
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal BasePrice { get; set; }

        public ICollection<PlanBenefit> Benefits { get; set; } = new List<PlanBenefit>();
        public ICollection<PlanPrice> PlanPrices { get; set; } = new List<PlanPrice>();
        public PlanPrice GetActivePrice() => PlanPrices.FirstOrDefault(x =>
            x.ForRenewOnly == false &&
            (x.EffectiveDate == null || x.EffectiveDate < DateTime.Now) &&
            (x.ExpirationDate == null || x.ExpirationDate > DateTime.Now));
    }
}
