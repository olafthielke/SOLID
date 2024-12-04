namespace SOLID.OCP.Switch.CompliantToo
{
    public class DpsPaymentGateway : IPaymentGateway
    {
        public string Name => "DPS";

        public void Pay(ShoppingCart cart, CreditCard card)
        {
            // Pay for cart via the DPS payment gateway.
        }
    }
}