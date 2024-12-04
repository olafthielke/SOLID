namespace SOLID.OCP.Switch.Compliant
{
    public interface IPaymentGateway
    {
        void Pay(ShoppingCart cart, CreditCard card);
    }
}