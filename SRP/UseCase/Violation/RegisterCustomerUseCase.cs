using System.Threading.Tasks;
using SOLID.DIP.UseCase;
using SOLID.DIP.UseCase.Compliant;
using SOLID.DIP.UseCase.Exceptions;

namespace SOLID.SRP.UseCase.Violation
{
    public class RegisterCustomerUseCase
    {
        public ICustomerRepository Repository { get; }


        public RegisterCustomerUseCase(ICustomerRepository repository)
        {
            Repository = repository;
        }


        public async Task<Customer> Register(CustomerRegistration reg)
        {
            if (reg == null)
                throw new MissingCustomerRegistration();

            if (string.IsNullOrWhiteSpace(reg.FirstName))
                throw new MissingFirstName();
            if (string.IsNullOrWhiteSpace(reg.LastName))
                throw new MissingLastName();
            if (string.IsNullOrWhiteSpace(reg.EmailAddress))
                throw new MissingEmailAddress();

            var existCust = await Repository.GetCustomer(reg.EmailAddress);
            if (existCust != null)
                throw new DuplicateCustomerEmailAddress(reg.EmailAddress);

            var customer = new Customer(reg.FirstName, reg.LastName, reg.EmailAddress);

            await Repository.SaveCustomer(customer);

            return customer;
        }
    }
}