namespace SOLID.OCP.CompliantToo
{
    public class PayForShoppingCartUseCase
    {
        private IPaymentGatewaySelector PaymentGatewaySelector { get; }

        public PayForShoppingCartUseCase(IPaymentGatewaySelector paymentGatewaySelector)
        {
            PaymentGatewaySelector = paymentGatewaySelector;
        }

        public void Pay(ShoppingCart cart, 
                        CreditCard creditCard,
                        string paymentGatewayName)
        {
            var paymentGateway = PaymentGatewaySelector.Select(paymentGatewayName);
            paymentGateway.Pay(cart, creditCard);
        }
    }
}