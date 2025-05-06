namespace Mehedi.CleanArchitecture.RedisCache.Infrastructure.Services;

public sealed class CacheOptions
{
    public const string Name = "CacheOptions";
    public int AbsoluteExpirationInHours { get; }
    public int SlidingExpirationInSeconds { get; }
}
