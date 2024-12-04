using System;

namespace SOLID.OCP.Switch
{
    public class UnknownPaymentGateway(string paymentGatewayName)
        : Exception($"'{paymentGatewayName}' is an unknown payment gateway.");
}