using System;
using System.ComponentModel.DataAnnotations;
using ViewModels.Attributes;

namespace ViewModels.Dtos
{
    public class CompanyProfileDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [NotEmptyGuid]
        public Guid State { get; set; }
        [RegularExpression(@"[0-9]{5}")]
        public string ZipCode { get; set; }

        public Guid? ActiveClaimId { get; set; }
    }
}   