namespace Domain.Entities
{
    public class EducationFocus
    {
        public Guid Id { get; set; }
        public Guid SchoolId { get; set; }
        public School School { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public bool IsCustom { get; set; }
    }
}
