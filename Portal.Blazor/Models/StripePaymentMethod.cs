namespace Portal.Blazor.Models
{
    public class StripePaymentMethod
    {
        public string Brand { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public string Last4 { get; set; }
        public string Cardholder { get; set; }
        public string Id { get; set; }
    }
}
