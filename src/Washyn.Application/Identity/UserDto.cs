using Volo.Abp.Application.Dtos;

namespace Washyn.Application.Identity
{
    public class UserDto : EntityDto<int>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
        public string RolName { get; set; }
    }
}