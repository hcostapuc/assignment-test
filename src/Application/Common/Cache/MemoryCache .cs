using System.Collections.Concurrent;
using Assignment.Application.Common.Interfaces;

namespace Assignment.Application.Common.Cache;
internal class MemoryCache : IMemoryCache
{
    private readonly ConcurrentDictionary<string, CacheItem> _cache = new ConcurrentDictionary<string, CacheItem>();

    public void Set<T>(string key, T value, TimeSpan expiration)
    {
        if (value is not null)
            _cache[key] = new CacheItem(value, DateTime.Now.Add(expiration));
    }

    public T Get<T>(string key) =>
        TryGetValue(key, out T value) ? value : default!;

    public bool TryGetValue<T>(string key, out T value)
    {
        value = default!;
        if (_cache.TryGetValue(key, out CacheItem? cacheItem))
        {
            if (cacheItem.ExpirationTime > DateTime.Now)
            {
                value = (T)cacheItem.Value;
                return true;
            }
            else
            {
                _cache.TryRemove(key, out _);
            }
        }
        return false;
    }

    public void Remove(string key) =>
        _cache.TryRemove(key, out _);
}
