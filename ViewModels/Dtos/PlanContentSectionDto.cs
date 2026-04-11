using System;
using System.Collections.Generic;

namespace ViewModels.Dtos
{
    public class PlanContentSectionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string LabelText { get; set; }
        public int DisplayOrder { get; set; }
        public List<PlanContentDto> PlanContents { get; set; }
    }
}