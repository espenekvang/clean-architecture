using Domain.Customer;
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

        public Customer FindBy(CustomerId customerId)
        {
            if (_customers.TryGetValue(customerId, out var customer))
            {
                return customer;
            }

            throw new ArgumentException($"Customer with id {customerId} not found.");
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
