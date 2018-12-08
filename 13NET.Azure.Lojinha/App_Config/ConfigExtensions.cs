using _13NET.Azure.Lojinha.Core.Services;
using _13NET.Azure.Lojinha.Infrastructure.Redis;
using _13NET.Azure.Lojinha.Infrastructure.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace _13NET.Azure.Lojinha.App_Config
{
    public static class ConfigExtensions
    {
        public static void AddAppDependencyInjections(this IServiceCollection service)
        {
            service.AddSingleton<IRedisCache, RedisCache>();
            service.AddScoped<IAzureStorage, AzureStorage>();
            service.AddScoped<IProdutoServices, ProdutoServices>();
            service.AddScoped<ICarrinhoServices, CarrinhoServices>();
        }
    }
}
