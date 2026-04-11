namespace Domain.Entities
{
    public class ItemRedemption
    {
        public Guid Id { get; set; }
        public Guid CompanyProfileId { get; set; }
        public CompanyProfile CompanyProfile { get; set; } = null!;
        public string ItemName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public DateTime RedeemedAt { get; set; } = DateTime.UtcNow;
    }
}
