using Domain.ValueTypes;

namespace Domain.Customer
{
    public class CustomerEntity    
    {
        public CustomerId CustomerId { get; }
        public CustomerName Name { get; }
        public Country Country { get; }

        public CustomerEntity(CustomerName name, CustomerId customerId, Country country)
        {
            CustomerId = customerId;
            Name = name;
            Country = country;
        }
    }
}