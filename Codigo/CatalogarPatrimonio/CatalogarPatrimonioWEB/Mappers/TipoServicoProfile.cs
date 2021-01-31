using AutoMapper;
using CatalogarPatrimonioWEB.Models;
using Core;

namespace CatalogarPatrimonioWEB.Mappers
{
    public class TipoServicoProfile : Profile 
    {
        public TipoServicoProfile()
        {
            CreateMap<TipoServicoModel,TipoServico>().ReverseMap();
        }
    }
}
