namespace SOLID.OCP.CompliantToo
{
    public interface IPaymentGateway
    {
        string Name { get; }
        void Pay(ShoppingCart cart, CreditCard card);
    }
}