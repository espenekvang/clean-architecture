using Domain.Customers;
using FluentMigrator.Runner;
using Infrastructure.Database;
using Infrastructure.Database.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<DapperContext>();
            services.AddSingleton<Database.Migrations.Database>();
            services.AddFluentMigratorCore()
                .ConfigureRunner(builder =>
                    builder
                        .AddSQLite()
                        .WithGlobalConnectionString(configuration.GetConnectionString("PowerDb"))
                        .ScanIn(typeof(InitialTables_202210132045).Assembly)
                        .For
                        .Migrations())
                .AddLogging(builder => builder.AddFluentMigratorConsole());
            return services;
        }
    }
}
