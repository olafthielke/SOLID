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
                customer.LastName,
                customer.EmailAddress
                // 18 more parameters!
                );

            // ...

            return customer;
        }


        private static void Validate(CustomerRegistration registration)
        {
            // TODO: Validate the CustomerRegistration.

            ValidateIsInactiveStatus();
        }


        private static void ValidateIsActiveStatus()
        {

        }

        private static void ValidateIsInactiveStatus()
        {

        }
    }
}