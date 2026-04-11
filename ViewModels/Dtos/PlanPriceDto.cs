using System;

namespace ViewModels.Dtos
{
    public class PlanPriceDto
    {
        public Guid Id { get; set; }
        public decimal BasePrice { get; set; }
        public decimal? SalePrice { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool ForRenewOnly { get; set; }
    }
}