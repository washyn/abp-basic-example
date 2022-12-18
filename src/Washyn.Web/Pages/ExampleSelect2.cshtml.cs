using Microsoft.AspNetCore.Mvc.RazorPages;
using Washyn.Application;

namespace Washyn.Web.Pages
{
    public class ExampleSelect2 : PageModel
    {
        
        public PruebaDto Prueba { get; set; }

        
        public void OnGet()
        {
            Prueba = new PruebaDto()
            {
                Id = 90022 ,
                Nombre = "string actulizado desde UI gg"
            };
        }
    }
}