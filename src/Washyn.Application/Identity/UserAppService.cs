using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Security.Encryption;
using Washyn.Domain.Identity;

namespace Washyn.Application.Identity
{
    public class UserAppService : CrudAppService<User, UserDto, int, PagedAndSortedResultRequestDto, CreateUserDto, UpdateUserDto>, IUserAppService
    {
        private readonly IStringEncryptionService _encryptionService;

        public UserAppService(IRepository<User, int> repository,
            IStringEncryptionService encryptionService) : base(repository)
        {
            _encryptionService = encryptionService;
        }

        public override async Task<UserDto> CreateAsync(CreateUserDto input)
        {
            var encriptedPasswd = _encryptionService.Encrypt(input.Password);
            var newUser = new User(userName: input.UserName, encriptedPasswd, RolConsts.Admin)
            {
                Email = input.Email,
                Name = input.Name,
                Surname = input.Surname,
                IsActive = input.IsActive,
                PhoneNumber = input.PhoneNumber,
            };
            var result = await this.Repository.InsertAsync(newUser);
            return ObjectMapper.Map<User, UserDto>(result);
        }

        public override async Task<UserDto> UpdateAsync(int id, UpdateUserDto input)
        {
            var encriptedPasswd = _encryptionService.Encrypt(input.Password);
            var user = await Repository.GetAsync(id);
            
            user.Email = input.Email;
            user.Name = input.Name;
            user.Surname = input.Surname;
            user.IsActive = input.IsActive;
            user.PhoneNumber = input.PhoneNumber;
            user.SetPassword(encriptedPasswd);
                
            var result = await this.Repository.UpdateAsync(user);
            return ObjectMapper.Map<User, UserDto>(result);
        }
    }
}