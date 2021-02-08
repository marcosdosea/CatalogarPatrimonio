using AutoMapper;
using CatalogarPatrimonioWEB.Models;
using Core;

namespace CatalogarPatrimonioWEB.Mappers
{
    public class PatrimonioProfile : Profile 
    {
        public PatrimonioProfile()
        {
            CreateMap<PatrimonioModel, Patrimonio>().ReverseMap();
        }
    }
}
