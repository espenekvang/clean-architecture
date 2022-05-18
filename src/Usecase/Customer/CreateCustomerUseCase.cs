using Domain.Customer;
using Domain.ValueTypes;

namespace UseCase.Customer
{
    internal class CreateCustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Domain.Customer.Customer Create(string name, string customerId, string country)
        {
            if (_customerRepository.FindBy(CustomerId.From(customerId)) != null)
            {
                throw new ArgumentException($"Customer with id ''{customerId}' already exists");
            }

            var customer = CustomerFactory.Create(name, customerId, country);

            _customerRepository.Save(customer);

            return customer;
        }
    }
}
