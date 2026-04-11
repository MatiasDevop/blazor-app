using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ViewModels.Attributes;

namespace ViewModels.Dtos
{
    
    public class SchoolDto
    {
        
        [EitherOrRequired(nameof(CollegeName))]
        public string UniversityName { get; set; }
        
        [EitherOrRequired(nameof(UniversityName))]
        public string CollegeName { get; set; }
        
        [Required]
        public string City { get; set; }
        [NotEmptyGuid]
        public Guid State { get; set; }
        [Required, RegularExpression("[0-9]{5}")]
        public string ZipCode { get; set; }
        public bool HasCareerCenter { get; set; }
        public bool Partner { get; set; }
        public Guid Id { get; set; }
        public Guid? ActiveClaimId { get; set; }

        public string DisplayName
        {
            get
            {
                var hasUniversity = !string.IsNullOrEmpty(UniversityName);
                var hasCollege = !string.IsNullOrEmpty(CollegeName);
                return hasCollege && hasUniversity
                    ? $"{UniversityName}: {CollegeName}"
                    : hasCollege && !hasUniversity
                        ? CollegeName
                        : UniversityName;
            }
        }
    }
}