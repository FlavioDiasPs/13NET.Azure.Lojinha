using _13NET.Azure.Lojinha.Core.Models;
using _13NET.Azure.Lojinha.Core.Services;
using _13NET.Azure.Lojinha.Core.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _13NET.Azure.Lojinha.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProdutoServices _produtoServices;
        
        public ProdutosController(IMapper mapper, IProdutoServices produtoServices)
        {
            _mapper = mapper;
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
            var produtos = await _produtoServices.GetProdutos();
            var vm = _mapper.Map<List<ProdutoViewModel>>(produtos);

            return View(vm);
        }

        public async Task<IActionResult> Details(string id)
        {
            var produto = await _produtoServices.GetProduto(id);
            return Json(produto);
        }
    }
}
