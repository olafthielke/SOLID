using System;

namespace SOLID.OCP
{
    public class UnknownPaymentGateway : Exception
    {
        public UnknownPaymentGateway(string paymentGatewayName)
            : base($"'{paymentGatewayName}' is an unknown payment gateway.")
            { }
    }
}