using System;
using Enums;

namespace ViewModels.Dtos
{
    public class DiscountDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? PercentageOff { get; set; }
        public decimal? MaxValue { get; set; }
        public DiscountTarget TargetType { get; set; }
        public Guid? TargetPlan { get; set; }
        public string Code { get; set; }
    }
}