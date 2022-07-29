namespace SOLID.OCP.Parameters.Violation
{
    public class DataAccess : IDataAccess
    {
        public void InsertCustomer(string firstName,
            string middleName,
            string lastName, 
            int age, 
            string emailAddress
            // 18 more parameters!
            )
            {
                // Create new customer in the database.
            }
    }
}