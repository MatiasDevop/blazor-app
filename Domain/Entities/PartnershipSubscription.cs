using Enums;

namespace Domain.Entities
{
    public class PartnershipSubscription
    {
        public Guid Id { get; set; }
        public Guid CompanyProfileId { get; set; }
        public CompanyProfile CompanyProfile { get; set; } = null!;
        public Guid PartnerPlanId { get; set; }
        public PartnerPlan Plan { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiresAt { get; set; }
        public SubscriptionStatus Status { get; set; }
    }
}
