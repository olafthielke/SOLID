namespace SOLID.OCP.Violation
{
    public class StripePaymentGateway
    {
        public void DoPayment(CreditCard card, ShoppingCart cart)
        {
            // Pay for cart via the Stripe payment gateway.
        }
    }
}