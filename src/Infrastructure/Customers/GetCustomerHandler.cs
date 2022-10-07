using Application;
using Domain.Customers;
using Domain.ValueTypes;

namespace Infrastructure.Customers
{
    public record GetCustomer(CustomerId CustomerId)
    {
        public static GetCustomer With(string customerId)
        {
            return new GetCustomer(CustomerId.From(customerId));
        }
    }

    internal class GetCustomerHandler : IQueryHandler<GetCustomer, Customer?>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public ValueTask<Customer?> Run(GetCustomer query, CancellationToken cancellationToken)
        {
            var customer = _customerRepository.FindBy(query.CustomerId);
            
            return ValueTask.FromResult(customer);
        }
    }
}
