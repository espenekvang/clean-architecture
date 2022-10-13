using Domain.ValueTypes;

namespace Domain.Customers
{
    public interface ICustomerRepository
    {
        public Task<Customer?> FindByAsync(CustomerId customerId);
        public Task SaveAsync(Customer customer);
    }
}
