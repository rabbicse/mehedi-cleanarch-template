using EventStore.Client;
using Mehedi.CleanArchitecture.EventStore.EventStoreDB.Infrastructure.Repositories;
using Mehedi.Application.SharedKernel.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mehedi.CleanArchitecture.EventStore.EventStoreDB.Infrastructure;

public class EventStoreDBConfig
{
    public string ConnectionString { get; set; } = default!;
}

public record EventStoreDBOptions(
    bool UseInternalCheckpointing = true
);

public static class DependencyInjections
{
    public static IServiceCollection AddEventStoreInfrastructureServices(
        this IServiceCollection services,
        IConfiguration config,
        EventStoreDBOptions? options = null
    )
    {
        var connectionString = config.GetConnectionString("EventStoreDbConnection");
        if (!string.IsNullOrEmpty(connectionString))
        {
            services.AddSingleton<EventStoreClient>(provider =>
            {
                var settings = EventStoreClientSettings.Create(connectionString);
                return new EventStoreClient(settings);
            });
        }

        return services.AddScoped<IEventStoreRepository, EventStoreRepository>();
    }

}
