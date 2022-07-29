namespace SOLID.OCP.Compliant
{
    public class PayForShoppingCartUseCase
    {
        private IPaymentGateway PaymentGateway { get; }

        public PayForShoppingCartUseCase(IPaymentGateway paymentGateway)
        {
            PaymentGateway = paymentGateway;
        }

        public void Pay(ShoppingCart cart, 
                        CreditCard creditCard)
        {
            PaymentGateway.Pay(cart, creditCard);
        }
    }
}