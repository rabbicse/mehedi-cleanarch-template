using Mehedi.Application.SharedKernel.Services;
using Mehedi.CleanArchitecture.RedisCache.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mehedi.CleanArchitecture.RedisCache.Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddCacheInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("CacheConnection");
        var instanceName = config?.GetSection("CacheOptions")["InstanceName"];

        services.AddOptions<CacheOptions>()
            .BindConfiguration(CacheOptions.Name, binderOptions => binderOptions.BindNonPublicProperties = true);
        return services.AddScoped<ICacheService, DistributedCacheService>()
            .AddStackExchangeRedisCache(redisOptions =>
            {
                redisOptions.InstanceName = instanceName;
                redisOptions.Configuration = connectionString;
            });
    }
}
