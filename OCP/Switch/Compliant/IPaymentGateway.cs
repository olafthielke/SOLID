namespace SOLID.OCP.Compliant
{
    public interface IPaymentGateway
    {
        void Pay(ShoppingCart cart, CreditCard card);
    }
}