using System.Collections.Generic;
using ViewModels.Dtos;

namespace ViewModels.Commands
{
    public class RegisterIndividualCommand : BaseRegisterCommand
    {
        public bool? MilitaryActiveDuty { get; set; }
        public SmartCodeDto PrimaryLanguage { get; set; }
        public List<WorkHistoryDto> WorkHistories { get; set; } = new();
        public List<EducationHistoryDto> EducationHistories { get; set; } = new();
    }
}