using System;

namespace SOLID.DIP.Identifier.Compliant
{
    public class CustomerIdentifier
    {
        public Guid OrgId { get; }
        public Guid CustomerId { get; }
        public string CustomerNumber { get; }

        public CustomerIdentifier(Guid orgId, Guid customerId, string customerNumber)
        {
            OrgId = orgId;
            CustomerId = customerId;
            CustomerNumber = customerNumber;
        }
    }
}
