using System;

namespace SOLID.DIP.UseCase.Exceptions
{
    public class DuplicateCustomerEmailAddress : Exception
    {
        public string EmailAddress { get; }

        public DuplicateCustomerEmailAddress(string emailAddress)
            : base($"The email address '{emailAddress}' already exists in the system.")
        {
            EmailAddress = emailAddress;
        }
    }
}
