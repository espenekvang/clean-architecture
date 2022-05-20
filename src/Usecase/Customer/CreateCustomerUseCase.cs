using Domain.Customer;
using Domain.ValueTypes;

namespace UseCase.Customer
{
    public class CreateCustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public (bool success, CustomerId customerId, string message) Create(string name, string customerId, string country)
        {
            if (_customerRepository.FindBy(CustomerId.From(customerId)) != null)
            {
                return (false, CustomerId.From(string.Empty), $"Customer with id '{customerId}' already exists");
            }

            var customer = CustomerFactory.Create(name, customerId, country);

            _customerRepository.Save(customer);

            return (true, customer.Id, "Customer created");
        }
    }
}
