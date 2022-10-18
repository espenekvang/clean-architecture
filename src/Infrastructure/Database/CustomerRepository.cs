using Dapper;
using Domain.Customers;
using Domain.MeteringPoint;
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
            var sql =
                "SELECT C.NAME AS NAME, C.CUSTOMER_ID AS CUSTOMERID, C.COUNTRY AS COUNTRY, M.METERING_POINT_ID AS METERINGPOINTID, M.NAME AS NAME, M.STREET AS STREET, M.ZIP AS ZIPCODE, M.POWER_ZONE AS POWERZONE " +
                "FROM CUSTOMER C LEFT OUTER JOIN METERING_POINT M ON C.CUSTOMER_ID = M.CUSTOMER_ID " +
                "WHERE C.CUSTOMER_ID=@Id";
            var customers = await connection.QueryAsync<Customer, MeteringPointEntity, Customer>(sql,
                (customer, meteringPointEntity) =>
                {
                    customer.AddMeteringPoint(meteringPointEntity);
                    return customer;
                },
                splitOn: "METERINGPOINTID",
                param: new { Id = customerId.Value });
            return customers.FirstOrDefault();

        }

        public async Task SaveAsync(Customer customer)
        {
            await using var connection = new SqliteConnection(_configuration.GetConnectionString("PowerDb"));

            await connection.ExecuteAsync(
                "INSERT INTO Customer(CUSTOMER_ID, NAME,COUNTRY) " +
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
