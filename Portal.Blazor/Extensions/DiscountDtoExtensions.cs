using System;
using ViewModels.Dtos;

namespace Portal.Blazor.Extensions
{
    public static class DiscountDtoExtensions
    {
        public static decimal ApplyDiscount(this DiscountDto discount, decimal value)
        {
            var maxPrice = discount.MaxValue ?? decimal.MaxValue;
            value -= Math.Min(maxPrice, value * (discount.PercentageOff ?? 0));
            if (value < 0)
                value = 0;
            return value;
        }
    }
}
