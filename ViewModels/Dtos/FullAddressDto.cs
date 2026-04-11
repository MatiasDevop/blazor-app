
namespace ViewModels.Dtos
{
    public class FullAddressDto
    {
        public string Line1 { get; set; }
        public string City { get; set; }
        public SmartCodeDto State { get; set; }
        public string ZipCode { get; set; }
        public SmartCodeDto Country { get; set; }
        public SmartCodeDto Region { get; set; }
    }
}