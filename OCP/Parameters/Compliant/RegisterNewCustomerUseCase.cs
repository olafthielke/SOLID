namespace SOLID.OCP.Parameters.Compliant
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
            DataAccess.InsertCustomer(customer);
            return customer;
        }


        private static void Validate(CustomerRegistration registration)
        {
            // TODO: Validate the CustomerRegistration.
        }
    }
}