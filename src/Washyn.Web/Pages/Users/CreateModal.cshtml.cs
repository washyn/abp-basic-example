using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Threading.Tasks;
using Washyn.Application.Identity;

namespace Washyn.Web.Pages.Users
{
    public class CreateModal : PageModel
    {

        [Inject]
        public IUserAppService Service { get; set; }
        
        [BindProperty]
        public CreateUserDto Model { get; set; }
        
        public void OnGet()
        {
            
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            await Service.CreateAsync(Model);
            return this.StatusCode((int)HttpStatusCode.OK);
        }
    }
}