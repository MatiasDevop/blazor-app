namespace Domain.Entities
{
    public class InvoiceHeader
    {
        public Guid Id { get; set; }
        public Guid CompanyProfileId { get; set; }
        public CompanyProfile CompanyProfile { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<InvoiceDetail> Details { get; set; } = new List<InvoiceDetail>();
        public ICollection<InvoiceDocument> Documents { get; set; } = new List<InvoiceDocument>();
    }
}
