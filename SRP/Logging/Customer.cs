using System;

namespace SOLID.SRP.Logging
{
    public class Customer
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string EmailAddress { get; }

        public Customer(string firstName, string lastName, string emailAddress)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
        }
    }
}
