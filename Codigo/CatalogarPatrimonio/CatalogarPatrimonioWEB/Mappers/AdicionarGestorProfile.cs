using AutoMapper;
using CatalogarPatrimonioWEB.Models;
using Core;

namespace CatalogarPatrimonioWEB.Mappers
{
    public class AdicionarGestorProfile : Profile
    {   
        public AdicionarGestorProfile()
        {
            CreateMap<AdicionarGestorModel, Pessoa>().ReverseMap();
        }
    }
}
