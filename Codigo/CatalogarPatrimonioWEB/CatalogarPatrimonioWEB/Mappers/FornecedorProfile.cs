using AutoMapper;
using CatalogarPatrimonioWEB.Models;
using Core;

namespace CatalogarPatrimonioWEB.Mappers
{
    public class FornecedorProfile : Profile
    {
        public FornecedorProfile()
        {
            CreateMap<FornecedorModel, Fornecedor>().ReverseMap();
        }
    }
}
