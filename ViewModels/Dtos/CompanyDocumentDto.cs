using System;
using System.ComponentModel.DataAnnotations;
using Enums;

namespace ViewModels.Dtos
{
    public class CompanyDocumentDto : BaseOrganizationDocumentDto
    {
        public CompanyDocumentType Type { get; set; }
    }
}