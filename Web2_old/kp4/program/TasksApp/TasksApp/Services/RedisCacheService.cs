using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;
using TasksApp.Interfaces;

namespace TasksApp.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private IDatabase _redis => _connectionMultiplexer.GetDatabase();

        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public async Task<string> GetCacheValueAsync(string key)
        {
            return await _redis.StringGetAsync(key);
        }

        public async Task SetCacheValueAsync(string key, string value)
        {
            await _redis.StringSetAsync(key, value); 
        }

        public async Task RemoveCacheKeyAsync(string key) 
        {
            await _redis.KeyDeleteAsync(key);
        }
    }
}
