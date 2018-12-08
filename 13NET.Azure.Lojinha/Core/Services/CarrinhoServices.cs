using _13NET.Azure.Lojinha.Core.Models;
using _13NET.Azure.Lojinha.Infrastructure.Redis;
using Newtonsoft.Json;

namespace _13NET.Azure.Lojinha.Core.Services
{
    public class CarrinhoServices : ICarrinhoServices
    {
        private readonly IRedisCache _cache;
        private const string _key = "a330286";

        public CarrinhoServices(IRedisCache cache)
        {
            this._cache = cache;            
        }

        public void Limpar(string usuario)
        {
            _cache.Set($"{_key}:carrinho:{usuario}", null);
        }

        public void Salvar(string usuario, Carrinho carrinho)
        {
            _cache.Set($"{_key}:carrinho:{usuario}", JsonConvert.SerializeObject(carrinho));
        }

        public Carrinho Get(string usuario)
        {
            var value = _cache.Get($"{_key}:carrinho:{usuario}");
            if(string.IsNullOrWhiteSpace(value))
            {
                var carrinho = new Carrinho();
                Salvar(usuario, carrinho);

                return carrinho;
            }

            return JsonConvert.DeserializeObject<Carrinho>(value);
        }
    }
}
