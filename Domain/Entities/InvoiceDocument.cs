namespace Domain.Entities
{
    public class InvoiceDocument
    {
        public Guid Id { get; set; }
        public Guid InvoiceHeaderId { get; set; }
        public InvoiceHeader InvoiceHeader { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public string? Url { get; set; }
    }
}
