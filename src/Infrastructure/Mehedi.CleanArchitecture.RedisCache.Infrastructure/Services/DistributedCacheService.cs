using System.Text;
using Mehedi.Application.SharedKernel.Extensions;
using Mehedi.Application.SharedKernel.Services;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Mehedi.CleanArchitecture.RedisCache.Infrastructure.Services;

internal sealed class DistributedCacheService : ICacheService
{
    private const string CacheServiceName = nameof(DistributedCacheService);
    private readonly DistributedCacheEntryOptions _cacheOptions;
    private readonly IDistributedCache _distributedCache;
    private readonly ILogger<DistributedCacheService> _logger;

    public DistributedCacheService(
        IDistributedCache distributedCache,
        ILogger<DistributedCacheService> logger,
        IOptions<CacheOptions> cacheOptions)
    {
        _distributedCache = distributedCache;
        _logger = logger;
        _cacheOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(cacheOptions.Value.AbsoluteExpirationInHours),
            SlidingExpiration = TimeSpan.FromSeconds(cacheOptions.Value.SlidingExpirationInSeconds)
        };
    }

    public async Task<TItem> GetOrCreateAsync<TItem>(string cacheKey, Func<Task<TItem>> factory)
    {
        var valueBytes = await _distributedCache.GetAsync(cacheKey).ConfigureAwait(false);
        if (valueBytes?.Length > 0)
        {
            LogFetched(_logger, CacheServiceName, cacheKey, null);

            var value = Encoding.UTF8.GetString(valueBytes);
            return value.FromJson<TItem>()!;
        }

        var item = await factory().ConfigureAwait(false);
        if (!object.Equals(item, default(TItem)))
        {
            LogAdded(_logger, CacheServiceName, cacheKey, null);

            var value = Encoding.UTF8.GetBytes(item.ToJson()!);
            await _distributedCache.SetAsync(cacheKey, value, _cacheOptions).ConfigureAwait(false);
        }

        return item;
    }

    public async Task<IReadOnlyList<TItem>> GetOrCreateAsync<TItem>(
            string cacheKey,
            Func<Task<IReadOnlyList<TItem>>> factory)
    {
        var valueBytes = await _distributedCache.GetAsync(cacheKey).ConfigureAwait(false);
        if (valueBytes?.Length > 0)
        {
            LogFetched(_logger, CacheServiceName, cacheKey, null);

            var values = Encoding.UTF8.GetString(valueBytes);
            return values.FromJson<IReadOnlyList<TItem>>() ?? Array.Empty<TItem>();

        }

        var items = await factory().ConfigureAwait(false);
        if (items?.Any() == true)
        {
            LogAdded(_logger, CacheServiceName, cacheKey, null);

            var value = Encoding.UTF8.GetBytes(items.ToJson()!);
            await _distributedCache.SetAsync(cacheKey, value, _cacheOptions).ConfigureAwait(false);
        }

        return items ?? Array.Empty<TItem>();
    }

    public async Task RemoveAsync(params string[] cacheKeys)
    {
        foreach (var cacheKey in cacheKeys)
        {
            LogRemoved(_logger, CacheServiceName, cacheKey, null);
            await _distributedCache.RemoveAsync(cacheKey).ConfigureAwait(false);
        }
    }

    #region Private-Method(s)
    private static readonly Action<ILogger, string, string, Exception?> LogFetched =
        LoggerMessage.Define<string, string>(LogLevel.Information, new EventId(1, nameof(LogFetched)),
            "Fetched from {CacheServiceName}: '{CacheKey}'");

    private static readonly Action<ILogger, string, string, Exception?> LogAdded =
        LoggerMessage.Define<string, string>(LogLevel.Information, new EventId(2, nameof(LogAdded)),
            "Added to {CacheServiceName}: '{CacheKey}'");

    private static readonly Action<ILogger, string, string, Exception?> LogRemoved =
        LoggerMessage.Define<string, string>(LogLevel.Information, new EventId(3, nameof(LogRemoved)),
            "Removed from {CacheServiceName}: '{CacheKey}'");
    #endregion
}
