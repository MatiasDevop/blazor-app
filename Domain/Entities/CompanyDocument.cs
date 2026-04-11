

namespace Domain.Entities
{
    public class CompanyDocument
    {
        public Guid Id { get; set; }
        public Guid CompanyProfileId { get; set; }
        public CompanyProfile CompanyProfile { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public string? Url { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        //public ZipFile File { get; set; }
    }
}
