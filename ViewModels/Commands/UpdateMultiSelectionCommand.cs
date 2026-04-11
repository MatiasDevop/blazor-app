using System;
using System.Collections.Generic;
using ViewModels.Dtos;

namespace ViewModels.Commands
{
    public class UpdateMultiSelectionCommand
    {
        public string SmartType { get; set; }
        public List<SmartCodeDto> SmartCodes { get; set; }
    }
}