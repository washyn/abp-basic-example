using AutoMapper;
using Washyn.Domain;

namespace Washyn.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Prueba, PruebaDto>().ReverseMap();
        }
    }
}