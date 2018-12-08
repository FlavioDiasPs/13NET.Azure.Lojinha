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
                Id = 330286_3,
                Nome = "Justin Bieber embaralhador de cartas",
                Descricao = "Sem qualquer habilidade motora, este pode destruir suas aulas de baralho.",
                Preco = 200m,
                Categoria = new Categoria() { Id = 330286_2, Nome = "Bailarina larga" },
                Fabricante = new Fabricante() { Id = 330286_2, Nome = "Kenzo and Harry Kids Toys" },
                Tags = new[] { "Bailarina", "Fiap", "Purpurina" },
                ImagemPrincipalUrl = @"https://scontent-gru2-1.xx.fbcdn.net/v/t1.0-9/13962529_1416259418400832_4260769363945976823_n.jpg?_nc_cat=106&_nc_ht=scontent-gru2-1.xx&oh=83240e10ec3535530960217dfd02c74e&oe=5C9DE4F0"
            };
            
            _produtoServices.AddProduto(produto);

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
