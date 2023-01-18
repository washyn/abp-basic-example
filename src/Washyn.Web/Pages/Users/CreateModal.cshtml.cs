using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Users;
using Washyn.Application.Identity;

namespace Washyn.Web.Pages.Users
{
    public class CreateModal : PageModel
    {

        [Inject]
        public IUserAppService Service { get; set; }
        [Inject]
        public IObjectMapper ObjectMapper { get; set; }

        [BindProperty]
        public CreateUserViewModel Model { get; set; }
        
        public void OnGet()
        {
            
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            await Service.CreateAsync(ObjectMapper.Map<CreateUserViewModel, CreateUserDto>(Model));
            return this.StatusCode((int)HttpStatusCode.OK);
        }
    }


    public class CreateUserViewModel
    {
        [Required]
        [Display(Name = "User")]
        [Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form.InputInfoText("Nombre de usuario.")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
         
        [Display(Name = "Activo")]
        [InputInfoText("La cuenta de usuario esta activa.")]
        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}