using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class NotEmptyGuidAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (!Guid.TryParse(value.ToString(), out var val))
                throw new InvalidCastException("Value is not a Guid");
            return val != Guid.Empty;
        }
    }
}