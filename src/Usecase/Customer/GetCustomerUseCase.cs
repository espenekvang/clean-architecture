using Domain.Customer;
using Domain.ValueTypes;

namespace UseCase.Customer
{
    public class GetCustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Domain.Customer.Customer? Get(CustomerId customerId)
        {
            return _customerRepository.FindBy(customerId);
        }
    }
}
