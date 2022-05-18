using Domain.ValueTypes;

namespace Domain.Customer
{
    public class CustomerEntity    
    {
        public CustomerId CustomerId { get; }
        public CustomerName CustomerName { get; }
        public Country Country { get; }

        public CustomerEntity(CustomerName customerName, CustomerId customerId, Country country)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            Country = country;
        }
    }
}