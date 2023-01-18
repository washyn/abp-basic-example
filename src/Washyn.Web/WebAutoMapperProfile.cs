using AutoMapper;
using Washyn.Application.Identity;
using Washyn.Web.Pages.Users;

namespace Washyn.Web
{
    public class WebAutoMapperProfile : Profile
    {
        public WebAutoMapperProfile()
        {
            CreateMap<CreateUserDto, CreateUserViewModel>().ReverseMap();
        }
    }
}