using Domain.Customers;
using Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>();
            return services;
        }
    }
}
