using Domain.ValueTypes;

namespace Domain.Customers
{
    public record CustomerEntity(CustomerName Name, CustomerId CustomerId, Country Country)
    {
        public CustomerEntity(string name, string customerId, string country) 
            : this(new CustomerName(name), new CustomerId(customerId), new Country(country))
        {

        }
    }
}