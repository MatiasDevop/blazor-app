namespace ViewModels.Commands
{
    public class RegisterOrganizationCommand : BaseRegisterCommand
    {
        public CreatePaymentMethodCommand PaymentMethod { get; set; } = new();
        public string PoNumber { get; set; }
    }
}