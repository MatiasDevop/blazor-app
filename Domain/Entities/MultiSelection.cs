namespace Domain.Entities
{
    public class MultiSelection
    {
        public Guid Id { get; set; }
        public Guid SmartTypeId { get; set; }
        public SmartType SmartType { get; set; } = null!;
        public Guid SmartCodeId { get; set; }
        public SmartCode Value { get; set; } = null!;

    }
}
