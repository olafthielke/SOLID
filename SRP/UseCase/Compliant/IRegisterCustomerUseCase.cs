using System.Threading.Tasks;

namespace SOLID.SRP.UseCase.Compliant
{
    public interface IRegisterCustomerUseCase
    {
        Task<Customer> Register(CustomerRegistration registration);
    }
}
