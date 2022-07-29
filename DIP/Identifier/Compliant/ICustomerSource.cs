using System.Threading.Tasks;

namespace SOLID.DIP.Identifier.Compliant
{
    public interface ICustomerSource
    {
        Task<Customer> GetCustomer(CustomerIdentifier customerIdentifier);
    }
}
