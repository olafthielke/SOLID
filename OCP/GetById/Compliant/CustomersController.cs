namespace SOLID.OCP.GetById.Compliant
{
    // WebApi2 simulated controller
    public class CustomersController : BaseController
    {
        private IDataAccess DataAccess { get; }

        public CustomersController(IDataAccess dataAccess)
        {
            DataAccess = dataAccess;
        }


        // [HttpGet]
        public HttpResponse GetCustomer(string id)
        {
            // ...

            var customer = DataAccess.GetById(id);

            // Simulate the return
            return customer;
        }
    }
}