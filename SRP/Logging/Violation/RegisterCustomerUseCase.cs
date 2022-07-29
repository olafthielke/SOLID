using System.Threading.Tasks;
using SOLID.DIP.UseCase.Exceptions;

namespace SOLID.SRP.Logging.Violation
{
    public class RegisterCustomerUseCase : IRegisterCustomerUseCase
    {
        public ICustomerRepository Repository { get; }
        public ILogger Logger { get; }


        public RegisterCustomerUseCase(ICustomerRepository repository, ILogger logger)
        {
            Repository = repository;
            Logger = logger;
        }


        public virtual async Task<Customer> Register(CustomerRegistration reg)
        {
            await Logger.LogInfo($"Start registration for customer '{reg.FirstName} {reg.LastName}'.");

            await Validate(reg);

            var cust = reg.ToCustomer();

            await Logger.LogInfo($"Start saving customer ({cust.FirstName} {cust.LastName}).");
            await Repository.SaveCustomer(cust);
            await Logger.LogInfo($"Customer {cust.FirstName} {cust.LastName} saved.");

            await Logger.LogInfo($"Successfully registered customer '{reg.FirstName} {reg.LastName}'.");

            return cust;
        }


        private async Task Validate(CustomerRegistration reg)
        {
            await Logger.LogInfo($"Start validating customer registration ({reg.FirstName} {reg.LastName}).");

            if (reg == null)
                throw new MissingCustomerRegistration();
            reg.Validate();
            var existCust = await Repository.GetCustomer(reg.EmailAddress);
            if (existCust != null)
                throw new DuplicateCustomerEmailAddress(reg.EmailAddress);

            await Logger.LogInfo($"Validation of customer registration successful ({reg.FirstName} {reg.LastName}).");
        }
    }
}