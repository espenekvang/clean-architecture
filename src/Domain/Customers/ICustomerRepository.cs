using Domain.ValueTypes;

namespace Domain.Customers
{
    public interface ICustomerRepository
    {
        public Customer? FindBy(CustomerId customerId);
        public void Save(Customer customer);
        public void Update(Customer customer);
    }
}
