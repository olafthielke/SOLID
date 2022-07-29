namespace SOLID.OCP.GetById.Violation
{
    // WebApi2 simulated controller
    public class CustomersController : XmlController
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

            var customer = GetCustomerById(id, 
                DataAccess.GetByIntId,
                DataAccess.GetByGuid);


            // Simulate the return
            return customer;
        }
    }
}