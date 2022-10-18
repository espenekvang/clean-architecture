using System.Transactions;
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
            const string sql = "SELECT C.NAME AS NAME, C.CUSTOMER_ID AS CUSTOMERID, C.COUNTRY AS COUNTRY, " +
                               "M.METERING_POINT_ID AS METERINGPOINTID, M.NAME AS NAME, M.STREET AS STREET, M.ZIP AS ZIPCODE, M.POWER_ZONE AS POWERZONE " +
                               "FROM CUSTOMER C " +
                               "LEFT OUTER JOIN METERING_POINT M " +
                               "ON C.CUSTOMER_ID = M.CUSTOMER_ID " +
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
            using var transactionScope = new TransactionScope();
            
            await SaveCustomerEntityAsync(customer);
            await SaveMeteringPointEntitiesAsync(customer.Id, customer.MeteringPoints);
            
            transactionScope.Complete();
        }

        public async Task UpdateAsync(Customer customer)
        {
            var existingCustomer = await FindByIdAsync(customer.Id);
            if (existingCustomer != null)
            {
                using var transactionScope = new TransactionScope();
                
                await UpdateCustomerEntityAsync(existingCustomer);
                await DeleteMeteringPointEntitiesAsync(existingCustomer.MeteringPoints);
                await SaveMeteringPointEntitiesAsync(customer.Id, customer.MeteringPoints);

                transactionScope.Complete();
            }

        }

        private async Task UpdateCustomerEntityAsync(Customer customer)
        {
            await using var connection = new SqliteConnection(_configuration.GetConnectionString("PowerDb"));

            await connection.ExecuteAsync(
                "UPDATE CUSTOMER " +
                "SET Name=@Name, Country=@Country " +
                "WHERE CUSTOMER_ID=@Id",
                new
                {
                    Name = customer.Name.Value, 
                    Country = customer.Country.Name,
                    Id = customer.Id.Value,
                });
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

        private async Task SaveMeteringPointEntitiesAsync(CustomerId customerId, List<MeteringPointEntity> meteringPoints)
        {
            await using var connection = new SqliteConnection(_configuration.GetConnectionString("PowerDb"));

            foreach (var meteringPointEntity in meteringPoints)
            {
                await connection.ExecuteAsync(
                    "INSERT INTO METERING_POINT(NAME, METERINGPOINT_ID, STREET, ZIP, POWER_ZONE, CUSTOMER_ID) " +
                    "VALUES (@Name, @MeteringPointId, @Street, @Zip, @PowerZone, @CustomerId)",
                    new
                    {
                        Name = meteringPointEntity.Name.Value,
                        MeteringPointId = meteringPointEntity.MeteringPointId.Value,
                        Street = meteringPointEntity.Address.Street,
                        Zip = meteringPointEntity.Address.ZipCode,
                        PowerZone = meteringPointEntity.PowerZone.Code,
                        CustomerId = customerId
                    });
            }
            
        }

        private async Task DeleteMeteringPointEntitiesAsync(List<MeteringPointEntity> meteringPoints)
        {
            await using var connection = new SqliteConnection(_configuration.GetConnectionString("PowerDb"));

            await connection.ExecuteAsync(
                "DELETE FROM METERING_POINT " +
                "WHERE METERING_POINT_ID IN @Ids",
                new { Ids = meteringPoints.Select(entity => entity.MeteringPointId.Value).ToList() });
        }
    }
}
