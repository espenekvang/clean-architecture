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

        public async Task<Customer?> FindByAsync(CustomerId customerId)
        {
            await using var connection = new SqliteConnection(_configuration.GetConnectionString("PowerDb"));
            var customers =
                (await connection.QueryAsync<Entities.Customer>("SELECT * FROM CUSTOMER WHERE Id=@Id",
                    new { Id = customerId.Value }))
                .ToList();

            if (!customers.Any()) return default(Customer);
            
            var customerDbEntity = customers[0];
            var customerEntity = new CustomerEntity(
                CustomerName.From(customerDbEntity.Name), 
                CustomerId.From(customerDbEntity.Id),
                Country.From(customerDbEntity.Country));

            return new Customer(customerEntity);

        }

        public async Task SaveAsync(Customer customer)
        {
            await using var connection = new SqliteConnection(_configuration.GetConnectionString("PowerDb"));

            await connection.ExecuteAsync("INSERT INTO Customer(Id, Name,Country) VALUES (@Id, @Name, @Country)",
                new
                {
                    Id = customer.Id.Value,
                    Name = customer.Name.Value,
                    Country = customer.Country.Name
                });
        }
    }
}
