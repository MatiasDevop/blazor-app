using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Attributes
{
    public class PastOrMaxDateTimeAttribute : ValidationAttribute
    {
        private readonly bool _allowMinValue;
        private readonly bool _allowMaxValue;

        public PastOrMaxDateTimeAttribute(bool allowMinValue = false, bool allowMaxValue = true)
        {
            _allowMinValue = allowMinValue;
            _allowMaxValue = allowMaxValue;
        }
        public override bool IsValid(object value)
        {
            if (value.GetType() != typeof(DateTime))
                throw new ArgumentException("Value is not a DateTime");
            var val = (DateTime)value;
            if (!_allowMinValue && val == DateTime.MinValue)
                return false;
            if (!_allowMaxValue && val == DateTime.MaxValue)
                return false;
            
            return val < DateTime.Now || val == DateTime.MaxValue;
        }
    }
}