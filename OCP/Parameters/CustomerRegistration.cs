namespace SOLID.OCP.Parameters
{
    public class CustomerRegistration
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string EmailAddress { get; set; }

        // more properties


        public Customer ToCustomer()
        {
            return new Customer
            {
                FirstName = this.FirstName,
                LastName = LastName,
                Age = Age,
                EmailAddress = EmailAddress
            };
        }
    }
}