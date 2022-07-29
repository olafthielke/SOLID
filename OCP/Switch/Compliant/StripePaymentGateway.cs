namespace SOLID.OCP.Compliant
{
    public class StripePaymentGateway : IPaymentGateway
    {
        public void Pay(ShoppingCart cart, CreditCard card)
        {
            // Pay for cart via the Stripe payment gateway.
        }
    }
}