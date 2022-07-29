using System.Threading.Tasks;

namespace SOLID.DIP.Identifier.Compliant
{
    public interface ICustomerDestination
    {
        Task SaveCustomer(Customer customer);
    }
}
