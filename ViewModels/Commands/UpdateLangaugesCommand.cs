using System.Collections.Generic;
using ViewModels.Dtos;

namespace ViewModels.Commands
{
    public class UpdateLangaugesCommand
    {
        public SmartCodeDto PrimaryLanguage { get; set; }
        public List<SmartCodeDto> SecondaryLanguages { get; set; }
    }
}