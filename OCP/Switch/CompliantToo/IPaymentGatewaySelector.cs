namespace SOLID.OCP.CompliantToo
{
    public interface IPaymentGatewaySelector
    {
        IPaymentGateway Select(string paymentGatewayName);
    }
}