using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Attributes
{
    public class RequiredAttributeWhenNotDateTimeMaxAttribute : DependentRequiredAttribute
    {
        public RequiredAttributeWhenNotDateTimeMaxAttribute(string otherProperty) : base(otherProperty)
        {
        }

        protected override bool IsRequired(object otherPropertyValue, ValidationContext validationContext)
        {
            return (DateTime)otherPropertyValue != DateTime.MaxValue;
        }
    }
}