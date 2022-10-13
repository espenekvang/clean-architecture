using Application.Customers.Queries;
using Domain.Customers;

namespace Application.Customers.Handlers
{
    internal class GetCustomerHandler : IQueryHandler<GetCustomerQuery, Customer?>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async ValueTask<Customer?> Handle(GetCustomerQuery query, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FindByAsync(query.CustomerId);

            return customer;
        }
    }
}
