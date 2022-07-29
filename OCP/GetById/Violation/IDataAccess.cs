using System;

namespace SOLID.OCP.GetById.Violation
{
    public interface IDataAccess
    {
        Customer GetByIntId(int id);
        Customer GetByGuid(Guid guid);
    }
}