using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Constants;
using Enums;
using ViewModels.Commands;

namespace ViewModels.Dtos
{
    public class SchoolClaimDto : BaseOrganizationClaimDto
    {
        public SchoolDto School { get; set; }
        public Dictionary<CareerCenterDocumentType, CareerCenterDocumentDto> Documents { get; set; }
        [Required]
        public string CareerCenterName { get; set; }

        public Guid InstitutionType { get; set; }
        public string WhoWeAre { get; set; }
    }
}