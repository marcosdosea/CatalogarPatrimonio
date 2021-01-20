using AutoMapper;
using CatalogarPatrimonioWEB.Models;
using Core;

namespace CatalogarPatrimonioWEB.Mappers
{
    public class AlmoxarifadoProfile : Profile 
    {
        public AlmoxarifadoProfile()
        {
            CreateMap<AlmoxarifadoModel, Almoxarifado>().ReverseMap();
        }
    }
}
