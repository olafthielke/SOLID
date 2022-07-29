using System.Threading.Tasks;

namespace SOLID.DIP.UseCase.Compliant
{
    public interface IRegisterCustomerUseCase
    {
        Task<Customer> Register(CustomerRegistration registration);
    }
}
