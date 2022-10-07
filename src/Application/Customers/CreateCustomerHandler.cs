using Domain.Customers;
using Domain.ValueTypes;

namespace Application.Customers
{
    public record CreateCustomer(string Name, CustomerId CustomerId, string Country)
    {
        public static CreateCustomer With(string name, string customerId, string country)
        {
            return new CreateCustomer(name, CustomerId.From(customerId), country);
        }
    }

    internal class CreateCustomerHandler : ICommandHandler<CreateCustomer>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public ValueTask Handle(CreateCustomer command, CancellationToken cancellationToken)
        {
            var (name, customerId, country) = command;

            if (_customerRepository.FindBy(customerId) != null)
            {
                throw new InvalidOperationException(
                    $"Customer with id: {customerId} already exists");
            }

            var customer = CustomerFactory.Create(name, customerId, country);

            _customerRepository.Save(customer);
            
            return ValueTask.CompletedTask;
        }
    }
}
