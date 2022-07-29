using System.Threading.Tasks;
using SOLID.DIP.UseCase.Exceptions;

namespace SOLID.DIP.UseCase.Violation
{
    public class RegisterCustomerUseCase
    {
        public SqlServerCustomerDatabase Database { get; }

        public RegisterCustomerUseCase(string connectionString)
        {
            // Dependency Inversion Principle Violation!
            Database = new SqlServerCustomerDatabase(connectionString);
        }

        public async Task<Customer> Register(CustomerRegistration registration)
        {
            await Validate(registration);
            var customer = CreateCustomer(registration);
            await SaveCustomer(customer);
            return customer;
        }

        protected async Task Validate(CustomerRegistration registration)
        {
            if (registration == null)
                throw new MissingCustomerRegistration();
            registration.Validate();
            var existCust = await Database.GetCustomer(registration.EmailAddress);
            if (existCust != null)
                throw new DuplicateCustomerEmailAddress(registration.EmailAddress);
        }

        protected Customer CreateCustomer(CustomerRegistration registration)
        {
            return registration.ToCustomer();
        }

        protected async Task SaveCustomer(Customer customer)
        {
            await Database.SaveCustomer(customer);
        }
    }
}