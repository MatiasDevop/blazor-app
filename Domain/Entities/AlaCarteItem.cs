namespace Domain.Entities
{
    public class AlaCarteItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool AllowMultiple { get; set; }
        public int DisplayOrder { get; set; }
        public string? DisplayGroup { get; set; }
        public bool Active { get; set; }
        public string? Availability { get; set; }
    }
}
