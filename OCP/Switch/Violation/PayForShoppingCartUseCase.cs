namespace SOLID.OCP.Violation
{
    public class PayForShoppingCartUseCase
    {
        public void Pay(ShoppingCart cart, 
                        CreditCard creditCard,
                        string paymentGatewayName)
        {
            switch (paymentGatewayName)
            {
                case "DPS":
                    var dpsGateway = new DpsPaymentGateway();
                    dpsGateway.Pay(cart, creditCard);
                    break;

                case "Stripe":
                    var stripeGateway = new StripePaymentGateway();
                    stripeGateway.DoPayment(creditCard, cart);
                    break;

                // Violates the OCP!
                // case "Braintree":
                //     var braintreeGateway = new BraintreePaymentGateway();
                //     braintreeGateway.BasicPay(creditCard, cart);
                //     break;

                default:
                    throw new UnknownPaymentGateway(paymentGatewayName);
            }
        }
    }
}