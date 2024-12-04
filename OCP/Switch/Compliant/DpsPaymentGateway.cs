namespace SOLID.OCP.Switch.Compliant
{
    public class DpsPaymentGateway : IPaymentGateway
    {
        public void Pay(ShoppingCart cart, CreditCard card)
        {
            // Pay for cart via the DPS payment gateway.
        }
    }
}