using AutoMapper;
using CatalogarPatrimonioWEB.Models;
using Core;

namespace CatalogarPatrimonioWEB.Mappers
{
    public class ServicoProfile : Profile
    {
        public ServicoProfile()
        {
            CreateMap<ServicoModel, Servico>().ReverseMap();
        }
    }
}
