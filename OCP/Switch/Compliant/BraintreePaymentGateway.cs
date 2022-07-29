namespace SOLID.OCP.Compliant
{
    public class BraintreePaymentGateway : IPaymentGateway
    {
        public void Pay(ShoppingCart cart, CreditCard card)
        {
            // Pay for cart via the Braintree payment gateway.
        }
    }
}