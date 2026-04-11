namespace Domain.Entities
{
    public class CompanyMultiSelection
    {
        public Guid Id { get; set; }
        public Guid CompanyProfileId { get; set; }
        public CompanyProfile CompanyProfile { get; set; } = null!;
        public Guid SmartTypeId { get; set; }
        public SmartType SmartType { get; set; } = null!;
        public Guid SmartCodeId { get; set; }
        public SmartCode SmartCode { get; set; } = null!;
        public SmartCode Value { get; set; } = null!;
        public string Field { get; set; } = string.Empty;
    }
}
