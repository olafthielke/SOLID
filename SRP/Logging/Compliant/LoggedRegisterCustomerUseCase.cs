using System.Threading.Tasks;
using SOLID.DIP.UseCase.Exceptions;

namespace SOLID.SRP.Logging.Compliant
{
    public class LoggedRegisterCustomerUseCase : RegisterCustomerUseCase
    {
        public ILogger Logger { get; }


        public LoggedRegisterCustomerUseCase(ICustomerRepository repository, ILogger logger)
            : base(repository)
        {
            Logger = logger;
        }


        public override async Task<Customer> Register(CustomerRegistration reg)
        {
            await Logger.LogInfo($"Start registration for customer '{reg.FirstName} {reg.LastName}'.");

            var customer = await base.Register(reg);

            await Logger.LogInfo($"Successfully registered customer '{reg.FirstName} {reg.LastName}'.");

            return customer;
        }


        protected override async Task Validate(CustomerRegistration reg)
        {
            await Logger.LogInfo($"Start validating customer registration ({reg.FirstName} {reg.LastName}).");

            await base.Validate(reg);

            await Logger.LogInfo($"Validation of customer registration successful ({reg.FirstName} {reg.LastName}).");
        }

        protected override async Task SaveCustomer(Customer cust)
        {
            await Logger.LogInfo($"Start saving customer ({cust.FirstName} {cust.LastName}).");

            await base.SaveCustomer(cust);

            await Logger.LogInfo($"Customer {cust.FirstName} {cust.LastName} saved.");
        }
    }
}