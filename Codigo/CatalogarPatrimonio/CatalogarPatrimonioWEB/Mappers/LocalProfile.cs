using AutoMapper;
using CatalogarPatrimonioWEB.Models;
using Core;

namespace CatalogarPatrimonioWEB.Mappers
{
    public class LocalProfile : Profile
    {
        CreateMap<LocalModel, Local>().ReverseMap();
    }
}
