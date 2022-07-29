using System;
using System.Threading.Tasks;

namespace SOLID.DIP.Identifier.Violation
{
    public interface ICustomerSource
    {
        Task<Customer> GetCustomer(Guid orgId, Guid customerId);
    }
}
