using EventStore.Client;
using Mehedi.CleanArchitecture.EventStore.EventStoreDB.Infrastructure.Repositories;
using Mehedi.Application.SharedKernel.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KYC.EventStore.EventStoreDB.Infrastructure;

public class EventStoreDBConfig
{
    public string ConnectionString { get; set; } = default!;
}

public record EventStoreDBOptions(
    bool UseInternalCheckpointing = true
);

public static class DependencyInjections
{
    private const string DefaultConfigKey = "EventStoreDbConnection";
    //public static IServiceCollection AddEventStoreDB(
    //    this IServiceCollection services,
    //    IConfiguration config,
    //    EventStoreDBOptions? options = null
    //) =>
    //    services.AddEventStoreDB(
    //        config,
    //        options
    //    );

    public static IServiceCollection AddEventStoreInfrastructureServices(
        this IServiceCollection services,
        IConfiguration config,
        EventStoreDBOptions? options = null
    )
    {
        var connectionString = config.GetConnectionString(DefaultConfigKey);
        var settings = EventStoreClientSettings.Create(connectionString);
        services
            .AddSingleton(new EventStoreClient(settings));

        return services.AddScoped<IEventStoreRepository, EventStoreRepository>();
    }

}
