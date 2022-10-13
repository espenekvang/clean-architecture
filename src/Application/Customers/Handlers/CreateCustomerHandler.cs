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

        public async ValueTask Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var (name, customerId, country) = command;

            if (await _customerRepository.FindByAsync(customerId) != null)
            {
                throw new InvalidOperationException(
                    $"Customer with id: {customerId} already exists");
            }

            var customer = CustomerFactory.Create(name, customerId, country);

            await _customerRepository.SaveAsync(customer);
        }
    }
}
