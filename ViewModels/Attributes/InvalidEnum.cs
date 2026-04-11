using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Attributes
{
    public class InvalidEnum : ValidationAttribute
    {
        public int InvalidValue { get; }

        public InvalidEnum(int invalidValue)
        {
            InvalidValue = invalidValue;
        }
        
        public override bool IsValid(object value)
        {
            return (int)value != InvalidValue;
        }
    }
}