using Domain.ValueTypes;

namespace Domain.Customers
{
    public class CustomerFactory
    {
        public static Customer Create(string name, CustomerId customerId, string country)
        {
            return new Customer(
                new CustomerEntity(
                    CustomerName.From(name),
                    customerId,
                    Country.From(country)
                )
            );
        }
    }
}
