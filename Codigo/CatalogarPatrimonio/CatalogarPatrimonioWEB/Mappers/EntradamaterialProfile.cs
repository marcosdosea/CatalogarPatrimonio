using AutoMapper;
using CatalogarPatrimonioWEB.Models;
using Core;

namespace CatalogarPatrimonioWEB.Mappers
{
    public class EntradamaterialProfile : Profile 
    {
        public EntradamaterialProfile()
        {
            CreateMap<EntradamaterialModel, Entradamaterial>().ReverseMap();
        }
    }
}
