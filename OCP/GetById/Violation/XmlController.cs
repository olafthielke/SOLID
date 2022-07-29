using System;

namespace SOLID.OCP.GetById.Violation
{
    // WebApi2 simulated controller
    public class XmlController //: ApiController
    {
        protected Customer GetCustomerById(string id,
            Func<int, Customer> getCustomerByIntId,
            Func<Guid, Customer> getCustomerByGuid)
        {
            // Try convert into an integer
            int intId;
            bool intParseSuccess = Int32.TryParse(id, out intId);
            if (intParseSuccess)
                return getCustomerByIntId(intId);

            // Try to convert into a GUID.
            Guid guid;
            bool guidParseSuccess = Guid.TryParse(id, out guid);
            if (guidParseSuccess)
                return getCustomerByGuid(guid);

            // Failed to convert => throw exception.
            throw new Exception($"'{id}' is an invalid identifier format.");
        }
    }
}