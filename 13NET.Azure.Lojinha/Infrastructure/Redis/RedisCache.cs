using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace _13NET.Azure.Lojinha.Infrastructure.Redis
{
    public class RedisCache : IRedisCache
    {
        private readonly IConfiguration _config;
        private readonly IDatabase _db;
        private readonly ConnectionMultiplexer _redis;

        public RedisCache(IConfiguration config)
        {
            _config = config;
            _redis = ConnectionMultiplexer.Connect(config.GetSection("Azure:Redis").Value);

            _db = _redis.GetDatabase();
        }

        public string Get(string key)
        {
            return _db.StringGet(key);
        }

        public void Set(string key, string value)
        {
            _db.StringSet(key, value);
        }
    }
}
