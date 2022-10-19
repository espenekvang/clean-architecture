using System.Transactions;
using Dapper;
using Domain.Customers;
using Domain.ValueTypes;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Database
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly IConfiguration _configuration;

        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Customer?> FindByIdAsync(CustomerId customerId)
        {
            await using var connection = new SqliteConnection(_configuration.GetConnectionString("PowerDb"));
            const string sql = "SELECT C.NAME AS NAME, C.CUSTOMER_ID AS CUSTOMERID, C.COUNTRY AS COUNTRY " +
                               "FROM CUSTOMER C " +
                               "WHERE C.CUSTOMER_ID=@Id";
            var customers = await connection.QueryAsync<Customer>(sql, new { Id = customerId.Value });
            return customers.FirstOrDefault();

        }

        public async Task SaveAsync(Customer customer)
        {
            using var transactionScope = new TransactionScope();
            
            await SaveCustomerEntityAsync(customer);

            transactionScope.Complete();
        }

        private async Task SaveCustomerEntityAsync(Customer customer)
        {
            await using var connection = new SqliteConnection(_configuration.GetConnectionString("PowerDb"));

            await connection.ExecuteAsync(
                "INSERT INTO CUSTOMER(CUSTOMER_ID, NAME,COUNTRY) " +
                "VALUES (@Id, @Name, @Country)",
                new
                {
                    Id = customer.Id.Value,
                    Name = customer.Name.Value,
                    Country = customer.Country.Name
                });
        }
    }
}
