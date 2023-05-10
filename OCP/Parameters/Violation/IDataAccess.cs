namespace SOLID.OCP.Parameters.Violation
{
    public interface IDataAccess
    {
        void InsertCustomer(string firstName,
            string middleName,
            string lastName,
            string emailAddress,
            int? age
            // 18 more parameters!
            );

        void InsertCustomer(string firstName,
            string lastName,
            string emailAddress
        // 18 more parameters!
        );
    }
}