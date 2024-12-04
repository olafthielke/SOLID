namespace SOLID.OCP.Switch.Compliant
{
    public class StripePaymentGateway : IPaymentGateway
    {
        public void Pay(ShoppingCart cart, CreditCard card)
        {
            // Pay for cart via the Stripe payment gateway.
        }
    }
}