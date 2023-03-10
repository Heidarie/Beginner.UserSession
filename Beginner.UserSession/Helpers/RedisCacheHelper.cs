using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;

namespace Beginner.UserSession.Helpers
{
    public class RedisCacheHelper : IRedisCacheHelper
    {
        IDistributedCache cache;
        public RedisCacheHelper(IConfiguration configuration)
        {
            var options = Options.Create(new RedisCacheOptions()
            {
                Configuration = configuration["AzureRedisConnection"]
            });

            cache = new RedisCache(options);
        }

        public void Set(string key, string value)
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1),
                SlidingExpiration = TimeSpan.FromDays(1),
            };
            cache.SetString(key, value, options);   
        }

        public string Get(string key)
        {
            var value = cache.GetString(key);
            return value;
        }

        public void Delete(string key)
        {
            cache.Remove(key);
        }
    }
}
