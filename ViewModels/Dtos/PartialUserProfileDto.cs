using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Constants;
using Enums;
using ViewModels.Attributes;
using ViewModels.ViewModels;

namespace ViewModels.Dtos
{
    public class PartialUserProfileDto : UserLabelVm
    {
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public SmartCodeDto GenderIdentity { get; set; }
        public string GenderIdentityOther { get; set; }

        public SmartCodeDto SexualIdentity { get; set; }
        public string SexualIdentityOther { get; set; }

        public SmartCodeDto RaceEthnicity { get; set; }
        public string RaceEthnicityOther { get; set; }
        public string PronounsIfOther { get; set; }
        public SmartCodeDto Pronouns { get; set; }
        public string EmailAddress { get; set; }
        public FullAddressDto MailingAddress { get; set; }
        public SmartCodeDto PrimaryLanguage { get; set; }
        public Dictionary<string, List<SmartCodeDto>> MultiSelections { get; set; }
        public bool IsMilitary { get; set; }
        public List<WorkHistoryDto> WorkHistories { get; set; }
        public List<EducationHistoryDto> EducationHistories { get; set; }
        public List<SocialLinkDto> SocialLinks { get; set; }
        public List<WorkSampleDto> WorkSamples { get; set; }
        public string Description { get; set; }
        public WorkAuthorizationType WorkAuthorization { get; set; }
        public string WorkAuthorizationOther { get; set; }
        public AttachmentDto Resume { get; set; }
    }
}