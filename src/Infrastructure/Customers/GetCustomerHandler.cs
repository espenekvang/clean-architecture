using Domain.Customers;
using Domain.ValueTypes;
using MediatR;

namespace Infrastructure.Customers
{
    public record GetCustomerQuery(CustomerId CustomerId) : IRequest<Customer?>
    {
        public static GetCustomerQuery With(string customerId)
        {
            return new GetCustomerQuery(CustomerId.From(customerId));
        }
    }

    internal class GetCustomerHandler : IRequestHandler<GetCustomerQuery, Customer?>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<Customer?> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = _customerRepository.FindBy(request.CustomerId);

            return Task.FromResult(customer);
        }
    }
}
