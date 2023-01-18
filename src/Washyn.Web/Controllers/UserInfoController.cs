using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Washyn.Web.CurrentUserExtraProps;
using Washyn.Web.Models;

namespace Washyn.Web.Controllers
{
    [AllowAnonymous]
    [Route("api/abp/application-user-configuration")]
    [ApiController]
    public class UserInfoController : Controller
    {
        private readonly IExtraPropCurrentUser _currentUser;

        public UserInfoController(IExtraPropCurrentUser currentUser)
        {
            _currentUser = currentUser;
            _currentUser = currentUser;
        }

        [HttpGet]
        public CustomCurrentUserDto Get()
        {
            return new CustomCurrentUserDto()
            {
                Id = _currentUser.UserId,
                Email = _currentUser.Email,
                Roles = _currentUser.Roles,
                Name = _currentUser.Name,
                IsAuthenticated = _currentUser.IsAuthenticated,
                SurName = _currentUser.SurName,
                PhoneNumber = _currentUser.PhoneNumber,
                UserName = _currentUser.UserName,
            };
        }
    }
}