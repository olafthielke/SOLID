using System.Collections.Generic;
using System.Linq;

namespace SOLID.OCP.CompliantToo
{
    public class PaymentGatewaySelector : IPaymentGatewaySelector
    {
        private IEnumerable<IPaymentGateway> PaymentGateways { get; }

        public PaymentGatewaySelector(IEnumerable<IPaymentGateway> paymentGateways)
        {
            PaymentGateways = paymentGateways;
        }

        public IPaymentGateway Select(string paymentGatewayName)
        {
            var paymentGateway = PaymentGateways.SingleOrDefault(pg => pg.Name == paymentGatewayName);
            if (paymentGateway == null)
                throw new UnknownPaymentGateway(paymentGatewayName);
            return paymentGateway;
        }
    }
}