using Domain.ValueTypes;

namespace Application.Customers.Commands;

public record CreateCustomerCommand(string Name, CustomerId CustomerId, string Country)
{
    public static CreateCustomerCommand With(string name, string customerId, string country)
    {
        return new CreateCustomerCommand(name, CustomerId.From(customerId), country);
    }
}