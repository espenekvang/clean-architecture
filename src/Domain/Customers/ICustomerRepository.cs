using Domain.ValueTypes;

namespace Domain.Customers
{
    public interface ICustomerRepository
    {
        public Task<Customer?> FindByIdAsync(CustomerId customerId);
        public Task SaveAsync(Customer customer);
    }
}
