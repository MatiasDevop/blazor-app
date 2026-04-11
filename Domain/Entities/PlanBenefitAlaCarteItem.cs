namespace Domain.Entities
{
    public class PlanBenefitAlaCarteItem
    {
        public Guid Id { get; set; }
        public Guid PlanBenefitId { get; set; }
        public PlanBenefit PlanBenefit { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
