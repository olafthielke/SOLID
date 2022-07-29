namespace SOLID.OCP.Parameters.Violation
{
    public interface IDataAccess
    {
        void InsertCustomer(string firstName,
            string middleName,
            string lastName, 
            int age, 
            string emailAddress
            // 18 more parameters!
            );
    }
}