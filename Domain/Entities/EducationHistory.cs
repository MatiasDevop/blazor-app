namespace Domain.Entities
{
    public class EducationHistory
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; } = null!;
        public string? SchoolName { get; set; }
        public string? Degree { get; set; }
        public string? Major { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<EducationFocus> Majors { get; set; }
        public ICollection<EducationFocus> Minors { get; set; }
        public DateTime GraduationDate { get; set; }
        public decimal GradePointAverage { get; set; }

    }
}
