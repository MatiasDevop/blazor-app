using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ViewModels.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class EitherOrRequiredAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessageFormatString =
            "Either {0} or {1} is required to have a value.";

        private readonly string _comparisonProperty;

        public EitherOrRequiredAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var property = context?.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
                throw new ArgumentException("Property with this name not found.");

            var comparisonValue = property.GetValue(context.ObjectInstance)?.ToString();

            return !string.IsNullOrWhiteSpace(value?.ToString()) || !string.IsNullOrWhiteSpace(comparisonValue)
                ? ValidationResult.Success
                : new ValidationResult(string.Format(DefaultErrorMessageFormatString, context.DisplayName,
                    _comparisonProperty));
        }
    }
}