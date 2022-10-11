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

        public ValueTask<Customer?> Handle(GetCustomerQuery query, CancellationToken cancellationToken)
        {
            var customer = _customerRepository.FindBy(query.CustomerId);
            
            return ValueTask.FromResult(customer);
        }
    }
}
