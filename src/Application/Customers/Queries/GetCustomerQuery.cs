using Domain.ValueTypes;

namespace Application.Customers.Queries;

public record GetCustomerQuery(CustomerId CustomerId)
{
    public static GetCustomerQuery With(string customerId)
    {
        return new GetCustomerQuery(CustomerId.From(customerId));
    }
}