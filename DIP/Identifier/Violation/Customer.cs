using System;

namespace SOLID.DIP.Identifier.Violation
{
    public class Customer
    {
        public Guid OrgId { get; }
        public Guid CustomerId { get; }
        public string CustomerNumber { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string EmailAddress { get; }

        public Customer(Guid orgId, Guid customerId, string customerNumber, 
            string firstName, string lastName, string emailAddress)
        {
            OrgId = orgId;
            CustomerId = customerId;
            CustomerNumber = customerNumber;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
        }
    }
}
