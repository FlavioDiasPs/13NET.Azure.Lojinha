using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _13NET.Azure.Lojinha.Core.Models
{
    public class Carrinho
    {
        public List<CarrinhoItem> Itens { get; set; }

        public Carrinho()
        {
            Itens = new List<CarrinhoItem>();
        }

        public void Add(Produto produto)
        {
            var item = Itens.FirstOrDefault(x => x.Produto.Id == produto.Id);
            if (item != null)
            {
                item.Quantidade++;
            }
            else
            {
                Itens.Add(new CarrinhoItem{
                    Produto = produto,
                    Quantidade = 1
                });
            }
        }
    }

    public class CarrinhoItem
    {        
        public CarrinhoItem()
        {
            
        }

        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }

}
