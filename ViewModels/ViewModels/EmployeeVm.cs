using System;
using System.Collections.Generic;
using ViewModels.Dtos;

namespace ViewModels.ViewModels
{
    public class EmployeeVm : UserLabelVm
    {
        public List<SmartCodeDto> HelpOffered { get; set; }
        public OrgUserConnectionDto Permissions { get; set; }
        public Guid OrgConnectionId { get; set; }
    }
}