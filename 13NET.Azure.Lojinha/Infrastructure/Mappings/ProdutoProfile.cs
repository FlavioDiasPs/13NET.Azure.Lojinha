using _13NET.Azure.Lojinha.Core.Models;
using _13NET.Azure.Lojinha.Core.ViewModels;
using AutoMapper;

namespace _13NET.Azure.Lojinha.Infrastructure.Mappings
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(p => p.Id, vm => vm.MapFrom(x => x.Id))
                .ForMember(p => p.Nome, vm => vm.MapFrom(x => x.Nome))
                .ForMember(p => p.Preco, vm => vm.MapFrom(x => x.Preco))
                .ForMember(p => p.ImagemUrl, vm => vm.MapFrom(x => x.ImagemPrincipalUrl));
        }
    }
}
