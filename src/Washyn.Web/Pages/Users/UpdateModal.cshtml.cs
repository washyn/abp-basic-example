using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Washyn.Application.Identity;

namespace Washyn.Web.Pages.Users
{
    public class UpdateModal : PageModel
    {

        [Inject]
        public IUserAppService Service { get; set; }
        
        [BindProperty]
        public UpdateUserDto Model { get; set; }
        
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var temp = await Service.GetAsync(Id);
            Model = new UpdateUserDto()
            {
                PhoneNumber = temp.PhoneNumber,
                Email = temp.Email,
                Name = temp.Name,
                Surname = temp.Surname,
                IsActive = temp.IsActive,
            };
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            await Service.UpdateAsync(Id, Model);
            return this.StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}