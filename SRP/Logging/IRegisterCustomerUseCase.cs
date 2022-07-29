using System.Threading.Tasks;

namespace SOLID.SRP.Logging
{
    public interface IRegisterCustomerUseCase
    {
        Task<Customer> Register(CustomerRegistration registration);
    }
}
