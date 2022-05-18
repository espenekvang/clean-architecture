using Domain.ValueTypes;

namespace Domain.Customer
{
    public class CustomerEntity    
    {
        public CustomerId Id { get; }
        public Name Name { get; }
        public Country Country { get; }

        public CustomerEntity(CustomerId id, Name name, Country country)
        {
            Id = id;
            Name = name;
            Country = country;
        }
    }
}