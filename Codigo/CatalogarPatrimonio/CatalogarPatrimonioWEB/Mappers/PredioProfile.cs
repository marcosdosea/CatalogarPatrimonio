using AutoMapper;
using CatalogarPatrimonioWEB.Models;
using Core;


namespace CatalogarPatrimonioWEB.Mappers
{
    public class PredioProfile : Profile
    {
        public PredioProfile()
        {
            CreateMap<PredioModel, Predio>().ReverseMap();
        }
    }
}
