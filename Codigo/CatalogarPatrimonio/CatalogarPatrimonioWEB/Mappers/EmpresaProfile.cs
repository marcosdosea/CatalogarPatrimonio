using AutoMapper;
using CatalogarPatrimonioWEB.Models;
using Core;


namespace CatalogarPatrimonioWEB.Mappers
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<EmpresaModel, Empresa>().ReverseMap();
        }

    }
}
