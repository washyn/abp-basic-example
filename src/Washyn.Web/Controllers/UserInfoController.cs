using Microsoft.AspNetCore.Mvc;
using Washyn.Web.Models;

namespace Washyn.Web.Controllers
{
    [Route("api/abp/application-user-configuration")]
    [ApiController]
    public class UserInfoController : Controller
    {
        private readonly ICustomCurrentUser _currentUser;

        public UserInfoController(ICustomCurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        [HttpGet]
        public CustomCurrentUserDto Get()
        {
            return new CustomCurrentUserDto()
            {
                Id = _currentUser.Id,
                Email = _currentUser.Email,
                Roles = _currentUser.Roles,
                Name = _currentUser.Name,
                IsAuthenticated = _currentUser.IsAuthenticated
            };
        }
    }
}