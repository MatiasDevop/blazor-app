using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Attributes
{
    public class DecimalValueRangeAttribute : ValidationAttribute
    {
        private readonly decimal _minValue;
        private readonly decimal _maxValue;

        public DecimalValueRangeAttribute(int minValue, int maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;
            var type = value.GetType();
            if (type != typeof(decimal) && type != typeof(decimal?))
                throw new ArgumentException($"{type} is not a decimal");
            var val = (decimal?)value;
            Console.WriteLine(val);
            return val >= _minValue && val < _maxValue;
        }
    }
}