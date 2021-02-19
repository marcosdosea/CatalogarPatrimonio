using AutoMapper;
using CatalogarPatrimonioWEB.Models;
using Core;

namespace CatalogarPatrimonioWEB.Mappers
{
    public class TipomaterialProfile : Profile
    {
        public TipomaterialProfile()
        {
            CreateMap<TipomaterialModel, Tipomaterial>().ReverseMap();
        }
    }
}
