using _13NET.Azure.Lojinha.Core.Models;

namespace _13NET.Azure.Lojinha.Core.Services
{
    public interface ICarrinhoServices
    {
        Carrinho Get(string usuario);
        void Limpar(string usuario);
        void Salvar(string usuario, Carrinho carrinho);
    }
}