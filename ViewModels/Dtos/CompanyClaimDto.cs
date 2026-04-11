using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Constants;
using Enums;
using ViewModels.Commands;

namespace ViewModels.Dtos
{
    public class CompanyClaimDto : BaseOrganizationClaimDto
    {
        public CompanyProfileDto Company { get; set; }
        public List<EducationFocusDto> Majors { get; set; }
        public Dictionary<string, List<SmartCodeDto>> MultiSelections { get; set; }
        public Dictionary<CompanyDocumentType, CompanyDocumentDto> Documents { get; set; }
        public WorkAuthorizationType WorkAuthorizationType { get; set; }
        public List<CompanyWorkAuthorizationDto> AcceptedWorkAuthorizations { get; set; }
        public string WorkAuthorizationOther { get; set; }
        public string AffinityGroupName { get; set; }
        public string AffinityGroupWebsite { get; set; }
        public string AffinityGroupDescription { get; set; }
    }
}