using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Alerts;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Security.Encryption;
using Washyn.Domain.Identity;

namespace Washyn.Web.Pages
{
    public class Login : AbpPageModel
    {
        [Inject]
        public IRepository<User, int> UserRepository { get; set; }
        
        [Inject]
        public ILogger<Login> Logger { get; set; }
        
        [Inject]
        public IStringEncryptionService EncryptionService { get; set; }


        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }
        
        [BindProperty]
        public LoginViewModel Model { get; set; }
        
        public IActionResult OnGet()
        {
            Model = new LoginViewModel()
            {
                Password = "chester",
                UserName = "chester"
            };
            Logger.LogInformation("ReturnUrl");
            Logger.LogInformation(ReturnUrl);
            if (HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Logger.LogInformation("ReturnUrl");
            Logger.LogInformation(ReturnUrl);
            
            if (ModelState.IsValid)
            {
                var user = await UserRepository.FindAsync(a => a.UserName == Model.UserName);
                if (user == null)
                {
                    // warn should not be show this message
                    ModelState.AddModelError("Model.UserName", "Not found user.");
                    return Page();
                }

                var encriptedPassword = EncryptionService.Encrypt(Model.Password);
                if (encriptedPassword == user.PasswordHash)
                {
                    await ExecLogin(user);
                    if (string.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect("/");
                    }
                    return Redirect(ReturnUrl);
                }
                // warn should not be show this message
                ModelState.AddModelError("Model.Password", "Wrong password.");
                return Page();
            }
            Alerts.Add(new AlertMessage(AlertType.Danger, "Add required fields."));
            return Page();
        }

        private async Task ExecLogin(User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.Role, user.RolName));
            var identityClaim = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(identityClaim);
            var authProps = new AuthenticationProperties()
            {
                ExpiresUtc = DateTime.Now.AddMinutes(100)
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProps);
        }
    }
    
    public class LoginViewModel
    {
        [Display(Name = "User name")]
        [Required]
        public string UserName { get; set; }
        
        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}