using Domain.Customers;
using Domain.ValueTypes;

namespace Infrastructure.Database
{
    internal class InMemoryCustomerRepository : ICustomerRepository
    {
        private readonly IDictionary<CustomerId, Customer> _customers;

        public InMemoryCustomerRepository()
        {
            _customers = new Dictionary<CustomerId, Customer>();
        }

        public Customer? FindBy(CustomerId customerId)
        {
            return _customers.TryGetValue(customerId, out var customer) ? customer : default(Customer);
        }

        public void Save(Customer customer)
        {
            Update(customer);
        }

        public void Update(Customer customer)
        {
            if (_customers.ContainsKey(customer.Id))
            {
                _customers.Remove(customer.Id);
            }
            _customers.Add(customer.Id, customer);
        }
    }
}
