namespace SOLID.OCP.Switch.CompliantToo
{
    public class BraintreePaymentGateway : IPaymentGateway
    {
        public string Name => "Braintree";

        public void Pay(ShoppingCart cart, CreditCard card)
        {
            // Pay for cart via the Braintree payment gateway.
        }
    }
}