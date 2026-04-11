using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Constants;
using Enums;
using ViewModels.Dtos;

namespace ViewModels.Commands
{
    public class BaseRegisterCommand : UserProfileDto
    {
        [Required]
        [RegularExpression(Validators.PasswordPattern, ErrorMessage = ValidatorMessages.PasswordMessage)]
        public string Password { get; set; }
        public AttachmentDto ProfileImage { get; set; }
        
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        
        public Dictionary<string, List<SmartCodeDto>> MultiSelections { get; set; }
    }
}