using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ViewModels.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public abstract class DependentRequiredAttribute : ValidationAttribute
    {
        public string OtherProperty { get; }

        public DependentRequiredAttribute(string otherProperty)
        {
            OtherProperty = otherProperty ?? throw new ArgumentNullException(nameof(otherProperty));
        }

        protected abstract bool IsRequired(object otherPropertyValue, ValidationContext validationContext);

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetRuntimeProperty(OtherProperty);
            if (otherPropertyInfo == null)
                return new ValidationResult($"Unknown Property: [{OtherProperty}]");
            
            if (otherPropertyInfo.GetIndexParameters().Any())
                throw new ArgumentException($"Common Property Not Found: [{OtherProperty}]");

            object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
            return IsRequired(otherPropertyValue, validationContext) && value == null
                ? new ValidationResult(ErrorMessage)
                : ValidationResult.Success;
        }
    }
}