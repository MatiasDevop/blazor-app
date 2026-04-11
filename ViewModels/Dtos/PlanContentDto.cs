using System;

namespace ViewModels.Dtos
{
    public class PlanContentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string LabelText { get; set; }
        public int DisplayOrder { get; set; }
    }
}