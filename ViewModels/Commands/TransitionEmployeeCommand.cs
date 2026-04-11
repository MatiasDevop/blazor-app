using System;
using System.Collections.Generic;
using Constants;
using ViewModels.Attributes;
using ViewModels.Dtos;

namespace ViewModels.Commands
{
    public class TransitionEmployeeCommand : UserProfileDto
    {
        public AttachmentDto ProfileImage { get; set; }
        public Dictionary<string, List<SmartCodeDto>> MultiSelections { get; set; }
        [NotEmptyGuid(ErrorMessage = ValidatorMessages.ProfileTypeMessage)]
        public Guid ProfileType { get; set; }
        public bool? MilitaryActiveDuty { get; set; }
        public SmartCodeDto PrimaryLanguage { get; set; }
        public List<WorkHistoryDto> WorkHistories { get; set; } = new();
        public List<EducationHistoryDto> EducationHistories { get; set; } = new();
    }
}