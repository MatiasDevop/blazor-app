namespace Domain.Entities
{
    public class PaymentAttempt
    {
        public Guid Id { get; set; }
        public Guid CompanyProfileId { get; set; }
        public CompanyProfile CompanyProfile { get; set; } = null!;
        public Guid? InvoiceHeaderId { get; set; }
        public InvoiceHeader? InvoiceHeader { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? Status { get; set; }
    }
}
