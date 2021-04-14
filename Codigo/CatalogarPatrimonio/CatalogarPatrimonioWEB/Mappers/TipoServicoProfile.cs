using AutoMapper;
using CatalogarPatrimonioWEB.Models;
using Core;

namespace CatalogarPatrimonioWEB.Mappers
{
    public class TiposervicoProfile : Profile 
    {
        public TiposervicoProfile()
        {
            CreateMap<TiposervicoModel,Tiposervico>().ReverseMap();
        }
    }
}
