using System;
using System.ComponentModel.DataAnnotations;
using Enums;
using ViewModels.Attributes;

namespace ViewModels.Dtos
{
    public class WorkHistoryDto : ICloneable
    {
        public Guid Id { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [NotEmptyGuid(ErrorMessage = "Employment Type is required.")]
        public Guid EmploymentType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string JobDescription { get; set; }
        [EitherOrRequired(nameof(CareerCenter))]
        public CompanyProfileDto Company { get; set; }
        [EitherOrRequired(nameof(Company))]
        public SchoolDto CareerCenter { get; set; }
        public EmploymentCategoryType EmploymentCategoryType { get; set; }

        public object Clone()
            => MemberwiseClone();
    }
}