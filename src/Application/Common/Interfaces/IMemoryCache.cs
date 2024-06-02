namespace Assignment.Application.Common.Interfaces;
public interface IMemoryCache
{
    void Set<T>(string key, T value, TimeSpan expiration);
    T Get<T>(string key);
    bool TryGetValue<T>(string key, out T value);
    void Remove(string key);
}
