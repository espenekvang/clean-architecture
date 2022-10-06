using Application.Customer;
using Domain.Customer;
using Infrastructure.Database;

namespace Web.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterCustomerServices(this IServiceCollection collection)
        {
            collection.AddTransient<CreateCustomerUseCase>();
            collection.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>();
        }
    }
}
