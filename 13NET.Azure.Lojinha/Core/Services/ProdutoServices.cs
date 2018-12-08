using _13NET.Azure.Lojinha.Core.Models;
using _13NET.Azure.Lojinha.Infrastructure.Redis;
using _13NET.Azure.Lojinha.Infrastructure.Storage;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _13NET.Azure.Lojinha.Core.Services
{
    public class ProdutoServices : IProdutoServices
    {
        private readonly IRedisCache _cache;
        private readonly IAzureStorage _storage;

        public ProdutoServices(IRedisCache cache, IAzureStorage storage)
        {
            this._cache = cache;
            this._storage = storage;
        }

        public async Task<List<Produto>> GetProdutos()
        {
            var key = "produtos";
            var value = _cache.Get(key);
            
            if(string.IsNullOrEmpty(value))
            {
                var produtos = await _storage.GetProdutos();
                _cache.Set(key, JsonConvert.SerializeObject(produtos));

                return produtos;
            }

            return JsonConvert.DeserializeObject<List<Produto>>(value);
        }
    }
}
