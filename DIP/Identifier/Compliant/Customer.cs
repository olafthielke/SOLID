﻿using System;

namespace SOLID.DIP.Identifier.Compliant
{
    public class Customer
    {
        public Guid OrgId => CustomerIdentifier.OrgId;
        public Guid? CustomerId => CustomerIdentifier.CustomerId;
        public string CustomerNumber => CustomerIdentifier.CustomerNumber;
        public string FirstName => CustomerDetails.FirstName;
        public string LastName => CustomerDetails.LastName;
        public string EmailAddress => CustomerDetails.EmailAddress;

        public CustomerIdentifier CustomerIdentifier { get; }
        public CustomerDetails CustomerDetails { get; }

        public Customer(CustomerIdentifier customerIdentifier,
            CustomerDetails customerDetails)
        {
            CustomerIdentifier = customerIdentifier;
            CustomerDetails = customerDetails;
        }
    }
}
