using Application.Customers.Commands;
using Domain.Customers;

namespace Application.Customers.Handlers
{
    internal class CreateCustomerHandler : ICommandHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public ValueTask Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
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
