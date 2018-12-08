using _13NET.Azure.Lojinha.Core.Models;
using _13NET.Azure.Lojinha.Core.Services;
using _13NET.Azure.Lojinha.Infrastructure.Storage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _13NET.Azure.Lojinha.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly IAzureStorage _azureStorage;
        private readonly IProdutoServices _produtoServices;
        public ProdutosController(IAzureStorage azureStorage, IProdutoServices produtoServices)
        {
            _azureStorage = azureStorage;
            _produtoServices = produtoServices;
        }

        public IActionResult Create()
        {
            var produto = new Produto
            {
                Id = 330286,
                Nome = "Renato em forma de purpurina",
                Descricao = "Extrato de divamór da treze net após lacre arrasador.",
                Preco = 1.99m,
                Categoria = new Categoria() { Id = 330286, Nome = "Humano concentrado" },
                Fabricante = new Fabricante() { Id = 330286, Nome = "Fiap human distributions" },
                Tags = new[] { "Humano", "Fiap", "Purpurina" },
                ImagemPrincipalUrl = @"https://i.cbc.ca/1.4466791.1514497691!/fileImage/httpImage/image.JPG_gen/derivatives/16x9_780/hellvetika.JPG"
            };

            //_azureStorage.AddProduto(produto);


            return Content("OK");
        }
        public async Task<IActionResult> List()
        {
            //return Json(await _azureStorage.GetProdutos());
            return Json(await _produtoServices.GetProdutos());
        }
    }
}
