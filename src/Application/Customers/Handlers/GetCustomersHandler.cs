using Application.Customers.Queries;
using Domain.Customers;

namespace Application.Customers.Handlers
{
    internal class GetCustomersHandler : IQueryHandler<GetCustomersQuery, IEnumerable<Customer>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomersHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async ValueTask<IEnumerable<Customer>> Handle(GetCustomersQuery query, CancellationToken cancellationToken)
        {
            return await _customerRepository.FindAllAsync();
        }
    }
}
