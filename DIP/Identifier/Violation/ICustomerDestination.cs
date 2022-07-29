using System.Threading.Tasks;

namespace SOLID.DIP.Identifier.Violation
{
    public interface ICustomerDestination
    {
        Task SaveCustomer(Customer customer);
    }
}
