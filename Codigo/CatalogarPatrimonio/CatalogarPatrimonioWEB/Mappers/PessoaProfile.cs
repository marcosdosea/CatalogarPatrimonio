using AutoMapper;
using CatalogarPatrimonioWEB.Models;
using Core;

namespace CatalogarPatrimonioWEB.Mappers
{
    public class PessoaProfile : Profile 
    {
        public PessoaProfile()
        {
            CreateMap<PessoaModel, Pessoa>().ReverseMap();
        }
    }
}
