namespace SOLID.OCP.Parameters.Violation
{
    public interface IDataAccess
    {
        void InsertCustomer(string firstName,
            string lastName,
            string emailAddress
        // 18 more parameters!
        );
    }
}