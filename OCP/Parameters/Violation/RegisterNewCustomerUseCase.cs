namespace SOLID.OCP.Parameters.Violation
{
    public class RegisterNewCustomerUseCase
    {
        private IDataAccess DataAccess { get; }

        public RegisterNewCustomerUseCase(IDataAccess dataAccess)
        {
            DataAccess = dataAccess;
        }

        public Customer RegisterCustomer(CustomerRegistration registration)
        {
            Validate(registration);
            var customer = registration.ToCustomer();

            // ...

            // TODO: Add customer.MiddleName.
            DataAccess.InsertCustomer(customer.FirstName,
                customer.MiddleName,
                customer.LastName,
                customer.Age,
                customer.EmailAddress
                // 18 more parameters!
                );

            // ...

            return customer;
        }


        private static void Validate(CustomerRegistration registration)
        {
            // TODO: Validate the CustomerRegistration.
        }
    }
}