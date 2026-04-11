using System;
using System.ComponentModel.DataAnnotations;
using Constants;
using ViewModels.Attributes;
using ViewModels.Dtos;

namespace ViewModels.Commands
{
    public class UpdateCareerCenterProfileCommand
    {
        [Required]
        public string CareerCenterName { get; set; }
        public AddressDto Address { get; set; }
        [NotEmptyGuid]
        public Guid OrganizationSize { get; set; }
        [NotEmptyGuid]
        public Guid InstitutionType { get; set; }
        [Required]
        public string Website { get; set; }
        [Required]
        [RegularExpression(Validators.EmailPattern, ErrorMessage = ValidatorMessages.EmailMessage)]
        public string Email { get; set; }
    }
}