using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Dtos
{
    public class AddressDto
    {
        public string Line1 { get; set; }
        public string City { get; set; }
        public Guid State { get; set; }
        [RegularExpression("[0-9]{5}")]
        public string ZipCode { get; set; }
        public Guid Country { get; set; }
        public Guid Region { get; set; }
    }
}