using CleanArchitecture.Domain.Aggregates.CustomerAggregate.Repositories;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repositories;
using Mehedi.Application.SharedKernel.Persistence;
using Mehedi.Core.SharedKernel;
using Mehedi.Write.RDBMS.Infrastructure.Abstractions.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure;

/// <summary>
/// Provides extension methods for configuring dependency injection services.
/// </summary>
public static class DependencyInjections
{
    /// <summary>
    /// Adds infrastructure services required for write operations to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The collection of services to add the infrastructure services to.</param>
    /// <param name="config">The configuration containing connection string information.</param>
    /// <returns>The modified <see cref="IServiceCollection"/> instance.</returns>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        string? connectionString = config.GetConnectionString("SqlConnection");

        return services

#if (UsePostgreSQL)
            // For Postgres Connection
            .AddDbContext<ApplicationWriteDbContext>(options =>
            {
                options.UseNpgsql(
                    connectionString,
                    npgsqlOptionsAction: npgsqlOptions =>
                    {
                        // Any additional configuration for SQL Server options can be applied here if needed               
                    });
            })
#else
            // For SQLServer Connection
            .AddDbContext<ApplicationWriteDbContext>(options =>
            {
                options.UseSqlServer(
                    connectionString,
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        // Any additional configuration for SQL Server options can be applied here if needed               
                    });
            })
#endif

        // Register the ApplicationDbContext as a scoped service implementing IWriteDbContext
        .AddScoped<IWriteDbContext>(provider => provider.GetRequiredService<ApplicationWriteDbContext>())

        // Register Dapper context
        .AddSingleton(sp => new ApplicationReadDbContext(connectionString))

        // Register the UnitOfWork as a scoped service implementing IUnitOfWork
        .AddScoped<IUnitOfWork, UnitOfWork>()

        // Register commands
        .AddRepositories();
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // Register the CustomerCommandRepository as a scoped service implementing ICustomerCommandRepository
        return services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
    }
}

