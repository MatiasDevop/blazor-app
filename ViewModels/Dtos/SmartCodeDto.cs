namespace ViewModels.Dtos
{
    public record SmartCodeDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public int Order { get; set; }

    }
}