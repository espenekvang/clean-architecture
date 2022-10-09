using Domain.Customers;
using Domain.ValueTypes;
using MediatR;

namespace Application.Customers
{
    public record CreateCustomerCommand(string Name, CustomerId CustomerId, string Country) : IRequest
    {
        public static CreateCustomerCommand With(string name, string customerId, string country)
        {
            return new CreateCustomerCommand(name, CustomerId.From(customerId), country);
        }
    }

    internal class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        Task<Unit> IRequestHandler<CreateCustomerCommand, Unit>.Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var (name, customerId, country) = request;

            if (_customerRepository.FindBy(customerId) != null)
            {
                throw new InvalidOperationException(
                    $"Customer with id: {customerId} already exists");
            }

            var customer = CustomerFactory.Create(name, customerId, country);

            _customerRepository.Save(customer);

            return Task.FromResult(new Unit());
        }
    }
}
