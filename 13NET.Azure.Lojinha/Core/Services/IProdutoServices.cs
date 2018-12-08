using System.Collections.Generic;
using System.Threading.Tasks;
using _13NET.Azure.Lojinha.Core.Models;

namespace _13NET.Azure.Lojinha.Core.Services
{
    public interface IProdutoServices
    {
        void AddProduto(Produto produto);
        Task<List<Produto>> GetProdutos();
        Task<Produto> GetProduto(string Id);
    }
}