using Domain.ValueTypes;

namespace Domain.Customers
{
    public class Customer
    {
        private readonly CustomerEntity _customerEntity;

        public CustomerId Id => _customerEntity.CustomerId;
        public CustomerName Name => _customerEntity.Name;
        public Country Country => _customerEntity.Country;

        public Customer(CustomerEntity customerEntity)
        {
            _customerEntity = customerEntity;            
        }

        public Customer(string name, string customerId, string country) :
            this(new CustomerEntity(name, customerId, country))
        {

        }
    }
}
