using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Washyn.Web.Pages.Users
{
    [Authorize]
    public class Index : PageModel
    {
        public void OnGet()
        {
            
        }
    }
}