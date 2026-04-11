
using System.ComponentModel.DataAnnotations;
using ViewModels.Attributes;

namespace ViewModels.Dtos
{
    public class EducationHistoryDto : ICloneable
    {
        public Guid Id { get; set; }
        [NotEmptyGuid]
        public Guid Degree { get; set; }
        [Required]
        public SchoolDto School { get; set; }

        [MinLength(1)] public List<EducationFocusDto> Majors { get; set; } = new();
        public List<EducationFocusDto> Minors { get; set; } = new();
        public string Specialization { get; set; }
        public DateTime GraduationDate { get; set; }

        [DecimalValueRange(0, 5)]
        public decimal? GradePointAverage { get; set; }

        public object Clone() =>
            MemberwiseClone();
    }
}