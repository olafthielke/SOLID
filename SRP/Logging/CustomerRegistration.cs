namespace SOLID.SRP.Logging
{
    public class CustomerRegistration
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string EmailAddress { get; }

        public CustomerRegistration(string firstName, string lastName, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
        }

        public void Validate()
        {
            // TODO: Validate the input data.
        }

        public Customer ToCustomer()
        {
            return new Customer(FirstName, LastName, EmailAddress);
        }
    }
}
