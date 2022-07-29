using System;

namespace SOLID.OCP.GetById.Violation
{
    public class DataAccess : IDataAccess
    {
        public Customer GetByIntId(int id)
        {
            // Retrieve customer by integer Id.

            return null;
        }

        public Customer GetByGuid(Guid guid)
        {
            // Retrieve customer by GUID.

            return null;
        }
    }
}