using System;
using System.Collections.Generic;
using Enums;
using ViewModels.Dtos;

namespace ViewModels.Commands
{
    public class UpdateUserProfileCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public Guid GenderIdentity { get; set; }
        public Guid SexualIdentity { get; set; }
        public Guid RaceEthnicity { get; set; }
        public string GenderIdentityOther { get; set; }
        public string SexualIdentityOther { get; set; }
        public string RaceEthnicityOther { get; set; }
        public string PronounsIfOther { get; set; }
        public Guid Pronouns { get; set; }
        public AddressDto MailingAddress { get; set; }
        public Guid PrimaryLanguage { get; set; }
        public bool? IsMilitary { get; set; }
        public string Description { get; set; }
        public ProfileType? ProfileType { get; set; }
    }
}