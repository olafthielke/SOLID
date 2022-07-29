using System.Threading.Tasks;

namespace SOLID.SRP.Logging
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomer(string emailAddress);

        Task SaveCustomer(Customer customer);
    }
}