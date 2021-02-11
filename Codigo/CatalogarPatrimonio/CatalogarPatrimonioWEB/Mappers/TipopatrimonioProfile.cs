using AutoMapper;
using CatalogarPatrimonioWEB.Models;
using Core;


namespace CatalogarPatrimonioWEB.Mappers
{
    public class TipopatrimonioProfile : Profile
    {
        public TipopatrimonioProfile()
        {
            CreateMap<TipopatrimonioModel, Tipopatrimonio>().ReverseMap();
        }

    }
}
