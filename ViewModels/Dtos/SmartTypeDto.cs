using System;
using System.Collections.Generic;

namespace ViewModels.Dtos
{
    public class SmartTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ToolTip { get; set; }
        public List<SmartCodeDto> SmartCodes { get; set; }
    }
}