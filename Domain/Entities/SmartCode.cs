namespace Domain.Entities
{
    public class SmartCode
    {
        public Guid Id { get; set; }
        public Guid SmartTypeId { get; set; }
        public SmartType SmartType { get; set; } = null!;
        public string Value { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public int Order { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsCustom { get; set; }
    }
}
