using System.Runtime.InteropServices;
using Domain.ValueTypes;

namespace Domain.Customer
{
    internal class CustomerFactory
    {
        public static Customer Create(string name, string customerId, string country)
        {
            return new Customer(
                new CustomerEntity(
                    new CustomerName(name),
                    new CustomerId(customerId),
                    new Country(country)
                )
            );
        }
    }
}
