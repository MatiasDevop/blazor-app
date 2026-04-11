namespace Domain.Entities
{
    public class PaymentMethod
    {
        public Guid Id { get; set; }
        public Guid CompanyProfileId { get; set; }
        public CompanyProfile CompanyProfile { get; set; } = null!;
        public string Type { get; set; } = string.Empty; // card, ach, etc.
        public string Name { get; set; }
        public string? MaskedDetails { get; set; }
        public bool IsDefault { get; set; }
        public string NameOnCard { get; set; }
        public string MaskedAccount { get; set; }
        public short ExpirationMonth { get; set; }
        public short ExpirationYear { get; set; }
        public string StripeId { get; set; }
    }
}
