using AutoMapper;
using Washyn.Application.Identity;
using Washyn.Domain;
using Washyn.Domain.Identity;

namespace Washyn.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Prueba, PruebaDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
        }
    }
}