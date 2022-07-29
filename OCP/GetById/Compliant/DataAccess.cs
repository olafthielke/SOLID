using System;

namespace SOLID.OCP.GetById.Compliant
{
    public class DataAccess : IDataAccess
    {
        public Customer GetById(string id)
        {
            // Retrieve customer by generic string id.

            // Try convert into an integer
            int intId;
            bool intParseSuccess = Int32.TryParse(id, out intId);
            if (intParseSuccess)
                return GetByIntId(intId);

            // Try to convert into a GUID.
            Guid guid;
            bool guidParseSuccess = Guid.TryParse(id, out guid);
            if (guidParseSuccess)
                return GetByGuid(guid);

            // Failed to convert => throw exception.
            throw new Exception($"'{id}' is an invalid identifier format.");
        }


        private Customer GetByIntId(int id)
        {
            // Retrieve customer by integer Id.

            return null;
        }

        private Customer GetByGuid(Guid guid)
        {
            // Retrieve customer by GUID.

            return null;
        }
    }
}