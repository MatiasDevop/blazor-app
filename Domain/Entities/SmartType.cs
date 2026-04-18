namespace Domain.Entities
{
    public class SmartType
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Category { get; set; }

        public ICollection<SmartCode> SmartCodes { get; set; } = new List<SmartCode>();
    }
}
