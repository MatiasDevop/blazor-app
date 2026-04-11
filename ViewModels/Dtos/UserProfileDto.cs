
using Constants;
using Enums;
using System.ComponentModel.DataAnnotations;
using ViewModels.Attributes;

namespace ViewModels.Dtos
{
    public class UserProfileDto
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        [Required]
        [RegularExpression(Validators.PhonePattern, ErrorMessage = ValidatorMessages.PhoneMessage)]
        public string Phone { get; set; }
        public bool PhoneKeepPrivate { get; set; }
        public Guid GenderIdentity { get; set; }
        public string GenderIdentityOther { get; set; }
        public Guid SexualIdentity { get; set; }
        public string SexualIdentityOther { get; set; }
        public Guid RaceEthnicity { get; set; }
        public string RaceEthnicityOther { get; set; }
        public string PronounsIfOther { get; set; }
        [NotEmptyGuid]
        public Guid Pronouns { get; set; }
        [RegularExpression(Validators.EmailPattern, ErrorMessage = ValidatorMessages.EmailMessage)]
        public string EmailAddress { get; set; }
        public AddressDto MailingAddress { get; set; }

        [Required(ErrorMessage = ValidatorMessages.ProfileTypeMessage)]
        public ProfileType? ProfileType { get; set; }

        public string Description { get; set; }
    }
}