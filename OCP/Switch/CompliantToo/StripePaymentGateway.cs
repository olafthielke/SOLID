namespace SOLID.OCP.CompliantToo
{
    public class StripePaymentGateway : IPaymentGateway
    {
        public string Name => "Stripe";

        public void Pay(ShoppingCart cart, CreditCard card)
        {
            // Pay for cart via the Stripe payment gateway.
        }
    }
}