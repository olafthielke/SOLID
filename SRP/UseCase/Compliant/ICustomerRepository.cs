using System.Threading.Tasks;

namespace SOLID.SRP.UseCase.Compliant
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomer(string emailAddress);

        Task SaveCustomer(Customer customer);
    }
}