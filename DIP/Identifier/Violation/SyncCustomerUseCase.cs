using System.Threading.Tasks;

namespace SOLID.DIP.Identifier.Violation
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
            var orgId = notification.OrgId;
            var customerId = notification.CustomerId;

            var customer = await CustomerSource.GetCustomer(orgId, customerId);
            if (customer != null)
                await CustomerDestination.SaveCustomer(customer);
        }
    }
}
