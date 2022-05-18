using Domain.ValueTypes;

namespace Domain.Customer
{
    internal interface ICustomerRepository
    {
        public Customer FindBy(CustomerId customerId);
        public void Save(Customer customer);
        public void Update(Customer customer);
    }
}
