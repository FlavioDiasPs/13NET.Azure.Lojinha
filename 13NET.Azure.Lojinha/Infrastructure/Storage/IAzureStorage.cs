using _13NET.Azure.Lojinha.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _13NET.Azure.Lojinha.Infrastructure.Storage
{
    public interface IAzureStorage
    {
        void AddProduto(Produto produto);
        Task<List<Produto>> GetProdutos();
    }
}