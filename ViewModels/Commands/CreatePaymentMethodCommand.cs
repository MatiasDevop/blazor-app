using Enums;

namespace ViewModels.Commands
{
    public class CreatePaymentMethodCommand
    {
        public string CustomerId { get; set; }
        public string PaymentMethodId { get; set; }
        public string PaymentId { get; set; }
        public PaymentMethodUsage Usage { get; set; }
        public bool AutoRenew { get; set; }
        public string Cardholder { get; set; }
        public string MaskedAccount { get; set; }
        public short ExpirationMonth { get; set; }
        public short ExpirationYear { get; set; }
        public string Name { get; set; }

        public PaymentMethodType Type { get; set; }
    }
}