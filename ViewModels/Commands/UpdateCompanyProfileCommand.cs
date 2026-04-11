using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Constants;
using Enums;
using ViewModels.Attributes;
using ViewModels.Dtos;

namespace ViewModels.Commands
{
    public class UpdateCompanyProfileCommand
    {
        public AddressDto Address { get; set; }
        [Required]
        public string Website { get; set; }
        [NotEmptyGuid]
        public Guid OrganizationSize { get; set; }
        [Required]
        [RegularExpression(Validators.EmailPattern, ErrorMessage = ValidatorMessages.EmailMessage)]
        public string Email { get; set; }
        public string Description { get; set; }
    }
}