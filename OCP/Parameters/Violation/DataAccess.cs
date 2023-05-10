namespace SOLID.OCP.Parameters.Violation
{
    public class DataAccess : IDataAccess
    {
        public void InsertCustomer(string firstName,
            string middleName,
            string lastName,
            string emailAddress,
            int? age
            // 18 more parameters!
        )
        {
            // Create new customer in the database.
        }

        public void InsertCustomer(string firstName,
            string lastName,
            string emailAddress
        )
        {
            InsertCustomer(firstName, null, lastName, emailAddress, null);
        }
    }
}