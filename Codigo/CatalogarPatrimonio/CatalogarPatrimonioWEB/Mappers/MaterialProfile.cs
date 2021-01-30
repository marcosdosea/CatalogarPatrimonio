using AutoMapper;
using CatalogarPatrimonioWEB.Models;
using Core;

namespace CatalogarPatrimonioWEB.Mappers
{
    public class MaterialProfile : Profile 
    {
        public MaterialProfile()
        {
            CreateMap<MaterialModel, Material>().ReverseMap();
        }
    }
}
