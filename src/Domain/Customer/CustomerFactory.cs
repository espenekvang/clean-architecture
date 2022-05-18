using Domain.ValueTypes;

namespace Domain.Customer
{
    public class CustomerFactory
    {
        public static Customer Create(string name, string customerId, string country)
        {
            return new Customer(
                new CustomerEntity(
                    CustomerName.From(name),
                    CustomerId.From(customerId),
                    Country.From(country)
                )
            );
        }
    }
}
