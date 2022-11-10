using Chromedia_TakeHomeExam.Interface;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Chromedia_TakeHomeExam.Services
{
    public class Cache : ICache
    {
        private readonly IMemoryCache _memoryCache;

        public Cache(IMemoryCache memCache)
        {
            _memoryCache = memCache;
        }

        public T GetFromCache<T>(string key)
        {

            if (_memoryCache.TryGetValue(key, out T cacheValue))
            {
                return cacheValue;
            }

            return default;
        }

        public void SetCache<T>(T obj, string key)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(1));

            _memoryCache.Set(key, obj, cacheEntryOptions);
        }
    }
}
