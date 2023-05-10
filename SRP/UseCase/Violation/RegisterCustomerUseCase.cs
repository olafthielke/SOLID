using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using SOLID.SRP.UseCase.Exceptions;

namespace SOLID.SRP.UseCase.Violation
{
    public class RegisterCustomerUseCase
    {
        public ISqlServerConfiguration SqlConfig { get; }


        public RegisterCustomerUseCase(ISqlServerConfiguration sqlConfig)
        {
            SqlConfig = sqlConfig;
        }


        public async Task<Customer> Register(CustomerRegistration reg)
        {
            if (reg == null)
                throw new MissingCustomerRegistration();

            if (string.IsNullOrWhiteSpace(reg.FirstName))
                throw new MissingFirstName();
            if (string.IsNullOrWhiteSpace(reg.LastName))
                throw new MissingLastName();
            if (string.IsNullOrWhiteSpace(reg.EmailAddress))
                throw new MissingEmailAddress();

            var existCust = await GetCustomer(reg.EmailAddress);
            if (existCust != null)
                throw new DuplicateCustomerEmailAddress(reg.EmailAddress);

            var customer = new Customer(Guid.NewGuid(), reg.FirstName, reg.LastName, reg.EmailAddress);

            await SaveCustomer(customer);

            return customer;
        }


        private async Task<Customer> GetCustomer(string emailAddress)
        {
            Customer customer = null;
            await using var connection = new SqlConnection(SqlConfig.ConnectionString);
            await connection.OpenAsync();

            var cmd = BuildGetCommand(emailAddress, connection);
            await using var reader = await cmd.ExecuteReaderAsync();
            while (reader.Read())
                customer = ReadCustomer(reader);

            connection.Close();

            return customer;
        }

        private async Task SaveCustomer(Customer customer)
        {
            await using var connection = new SqlConnection(SqlConfig.ConnectionString);
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
            var guid = new Guid(reader["Guid"].ToString());
            var firstName = reader["FirstName"].ToString();
            var lastName = reader["LastName"].ToString();
            var email = reader["EmailAddress"].ToString();

            return new Customer(guid, firstName, lastName, email);
        }
    }
}