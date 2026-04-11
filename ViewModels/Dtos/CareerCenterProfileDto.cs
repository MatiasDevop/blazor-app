using System;
using System.ComponentModel.DataAnnotations;
using Enums;
using ViewModels.Attributes;

namespace ViewModels.Dtos
{
    public class CareerCenterProfileDto
    {
        public Guid Id { get; set; }
        [EitherOrRequired("CollegeName")]
        public string UniversityName { get; set; }
        [EitherOrRequired("UniversityName")]
        public string CollegeName { get; set; }
        [Required]
        public string City { get; set; }
        [NotEmptyGuid]
        public Guid State { get; set; }
        [RegularExpression(@"[0-9]{5}")]
        public string ZipCode { get; set; }
    }
}