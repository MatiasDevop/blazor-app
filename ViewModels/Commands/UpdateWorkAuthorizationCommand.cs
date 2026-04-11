using System.Collections.Generic;
using Enums;
using ViewModels.Dtos;

namespace ViewModels.Commands
{
    public class UpdateWorkAuthorizationCommand
    {
        public WorkAuthorizationType WorkAuthorization { get; set; }
        public string WorkAuthorizationOther { get; set; }
        public List<CompanyWorkAuthorizationDto> CompanyWorkAuthorizations { get; set; }
    }
}