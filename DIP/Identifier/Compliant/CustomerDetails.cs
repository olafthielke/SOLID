namespace SOLID.DIP.Identifier.Compliant
{
    public class CustomerDetails
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string EmailAddress { get; }

        public CustomerDetails(string firstName, string lastName, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
        }
    }
}
