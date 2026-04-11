using System;
using System.Collections.Generic;
using Enums;

namespace ViewModels.Dtos
{
    public class PartnerPlanDto
    {
        public Guid Id { get; set; }
        public PlanType PlanType { get; set; }
        public AttachmentDto PlanIcon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public PlanPriceDto CurrentPrice { get; set; }
        public int DisplayOrder { get; set; }
        public string IconBackgroundColor { get; set; }
        public List<PlanContentSectionDto> PlanContentSections { get; set; }
    }
}