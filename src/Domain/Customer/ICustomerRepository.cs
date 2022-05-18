using Domain.ValueTypes;

namespace Domain.Customer
{
    public interface ICustomerRepository
    {
        public Customer FindBy(CustomerId customerId);
        public void Save(Customer customer);
        public void Update(Customer customer);
    }
}
