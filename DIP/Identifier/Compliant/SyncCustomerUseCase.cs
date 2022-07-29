using System.Threading.Tasks;

namespace SOLID.DIP.Identifier.Compliant
{
    // High-level Business Logic workflow
    public class SyncCustomerUseCase
    {
        private ICustomerSource CustomerSource { get; }
        private ICustomerDestination CustomerDestination { get; }

        public SyncCustomerUseCase(ICustomerSource customerSource, 
            ICustomerDestination customerDestination)
        {
            CustomerSource = customerSource;
            CustomerDestination = customerDestination;
        }

        public async Task Sync(CustomerChangedNotification notification)
        {
            var customer = await CustomerSource.GetCustomer(notification.CustomerIdentifier);
            if (customer != null)
                await CustomerDestination.SaveCustomer(customer);
        }
    }
}
