using _13NET.Azure.Lojinha.Core.Models;
using _13NET.Azure.Lojinha.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _13NET.Azure.Lojinha.Controllers
{
    [Authorize]
    public class CarrinhoController : Controller
    {
        private readonly IProdutoServices _produtoServices;
        private readonly ICarrinhoServices _carrinhoServices;

        public CarrinhoController(IProdutoServices produtoServices, ICarrinhoServices carrinhoServices)
        {
            _produtoServices = produtoServices;
            _carrinhoServices = carrinhoServices;
        }
        public async Task<IActionResult> Add(string id)
        {
            var usuario = HttpContext.User.Identity.Name;

            Carrinho carrinho = _carrinhoServices.Get(usuario);

            carrinho.Add(await _produtoServices.GetProduto(id));

            _carrinhoServices.Salvar(usuario, carrinho);

            return PartialView("Index", carrinho);
        }

        public IActionResult Finalizar()
        {
            var usuario = HttpContext.User.Identity.Name;
            var carrinho = _carrinhoServices.Get(usuario);

            _carrinhoServices.Limpar(usuario);

            return View(carrinho);
        }
    }
}
