using System.Threading.Tasks;
using SOLID.DIP.UseCase.Exceptions;

namespace SOLID.SRP.Logging.Compliant
{
    public class RegisterCustomerUseCase : IRegisterCustomerUseCase
    {
        public ICustomerRepository Repository { get; }


        public RegisterCustomerUseCase(ICustomerRepository repository)
        {
            Repository = repository;
        }


        public virtual async Task<Customer> Register(CustomerRegistration registration)
        {
            await Validate(registration);
            var customer = CreateCustomer(registration);
            await SaveCustomer(customer);
            return customer;
        }


        protected virtual async Task Validate(CustomerRegistration registration)
        {
            if (registration == null)
                throw new MissingCustomerRegistration();
            registration.Validate();
            var existCust = await Repository.GetCustomer(registration.EmailAddress);
            if (existCust != null)
                throw new DuplicateCustomerEmailAddress(registration.EmailAddress);
        }

        protected virtual Customer CreateCustomer(CustomerRegistration registration)
        {
            return registration.ToCustomer();
        }

        protected virtual async Task SaveCustomer(Customer customer)
        {
            await Repository.SaveCustomer(customer);
        }
    }
}