using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SOLID.DIP.UseCase.Violation
{
    public class SqlServerCustomerDatabase
    {
        private string ConnectionString { get; }

        public SqlServerCustomerDatabase(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public async Task<Customer> GetCustomer(string emailAddress)
        {
            Customer customer = null;
            await using var connection = new SqlConnection(ConnectionString);
            await connection.OpenAsync();

            var cmd = BuildGetCommand(emailAddress, connection);
            await using var reader = await cmd.ExecuteReaderAsync();
            while (reader.Read())
                customer = ReadCustomer(reader);

            connection.Close();

            return customer;
        }

        public async Task SaveCustomer(Customer customer)
        {
            await using var connection = new SqlConnection(ConnectionString);
            await connection.OpenAsync();

            var cmd = BuildSaveCommand(customer, connection);
            await cmd.ExecuteNonQueryAsync();

            connection.Close();
        }


        private static SqlCommand BuildGetCommand(string emailAddress, SqlConnection connection)
        {
            return new SqlCommand($"SELECT * FROM [dbo].[Customers] WHERE [EmailAddress] = '{emailAddress}'", connection);
        }

        private static SqlCommand BuildSaveCommand(Customer customer, SqlConnection connection)
        {
            return new SqlCommand($"INSERT INTO [dbo].[Customers] ([FirstName], [LastName], [EmailAddress]) VALUES ('{customer.FirstName}', '{customer.LastName}', '{customer.EmailAddress}')", connection);
        }

        private static Customer ReadCustomer(SqlDataReader reader)
        {
            var firstName = reader["FirstName"].ToString();
            var lastName = reader["LastName"].ToString();
            var email = reader["EmailAddress"].ToString();

            return new Customer(firstName, lastName, email);
        }
    }
}
