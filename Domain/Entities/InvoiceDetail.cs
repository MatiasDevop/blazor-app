namespace Domain.Entities
{
    public class InvoiceDetail
    {
        public Guid Id { get; set; }
        public Guid InvoiceHeaderId { get; set; }
        public InvoiceHeader InvoiceHeader { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
