using AutoMapper;
using CatalogarPatrimonioWEB.Models;
using Core;


namespace CatalogarPatrimonioWEB.Mappers
{
    public class EntradaProfile : Profile
    {
        public EntradaProfile()
        {
            CreateMap<EntradaModel, Entrada>().ReverseMap();
        }

    }
}
