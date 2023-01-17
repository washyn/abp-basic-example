using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Washyn.Domain.Identity;

namespace Washyn.Application.Identity
{
    public interface IUserAppService : ICrudAppService<UserDto, int, PagedAndSortedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        
    }
}