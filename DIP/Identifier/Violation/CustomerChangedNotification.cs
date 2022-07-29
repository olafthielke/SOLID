using System;

namespace SOLID.DIP.Identifier.Violation
{
    public class CustomerChangedNotification
    {
        public Guid OrgId { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}
