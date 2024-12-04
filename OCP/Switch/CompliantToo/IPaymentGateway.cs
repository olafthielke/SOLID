namespace SOLID.OCP.Switch.CompliantToo
{
    public interface IPaymentGateway
    {
        string Name { get; }
        void Pay(ShoppingCart cart, CreditCard card);
    }
}