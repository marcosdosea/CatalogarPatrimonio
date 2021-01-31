using AutoMapper;
using CatalogarPatrimonioWEB.Models;
using Core;

namespace CatalogarPatrimonioWEB.Mappers
{
    public class LocalProfile : Profile
    {
        public LocalProfile() 
        {
            CreateMap<LocalModel, Local>().ReverseMap();
        }
    }
}
