
namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        void Add(string key, object value, int duration);
        T Get<T>(string key);
        object Get(string key);  // Type casting gerekli olacaktir
        bool IsAdd(string key); // Cache te var mi
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
