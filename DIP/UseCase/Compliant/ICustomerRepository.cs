using System.Threading.Tasks;

namespace SOLID.DIP.UseCase.Compliant
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomer(string emailAddress);

        Task SaveCustomer(Customer customer);
    }
}