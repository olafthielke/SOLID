namespace SOLID.OCP.Switch.CompliantToo
{
    public interface IPaymentGatewaySelector
    {
        IPaymentGateway Select(string paymentGatewayName);
    }
}