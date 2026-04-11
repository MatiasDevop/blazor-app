using System;
using System.ComponentModel.DataAnnotations;
using Enums;

namespace ViewModels.Dtos
{
    public class CareerCenterDocumentDto : BaseOrganizationDocumentDto
    {
        public CareerCenterDocumentType Type { get; set; }
    }
}