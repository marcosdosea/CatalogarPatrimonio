using AutoMapper;
using CatalogarPatrimonioWEB.Models;
using Core;

namespace CatalogarPatrimonioWEB.Mappers
{
    public class DialogoservicoProfile : Profile
    {
        public DialogoservicoProfile()
        {
            CreateMap<DialogoservicoModel, DialogoservicoService>().ReverseMap();
        }
    }
}
