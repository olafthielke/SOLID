namespace SOLID.OCP.GetById.Compliant
{
    public interface IDataAccess
    {
        Customer GetById(string id);
    }
}