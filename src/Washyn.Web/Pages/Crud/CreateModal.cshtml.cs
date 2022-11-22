using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Washyn.Application;

namespace Washyn.Web.Pages.Crud
{
    public class CreateModal : AbpPageModel
    {
        [Inject]
        public IPruebaAppService PruebaAppService { get; set; }

        [BindProperty]
        public CreateEditGroupViewModel ViewModel { get; set; }

        public CreateModal()
        {
           
        }
        
        public async Task OnGetAsync()
        {
            
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            var model = new PruebaDto() { Nombre = ViewModel.Nombre };
            await PruebaAppService.CreateAsync(model);
            return NoContent();
        }
    }
    
    public class CreateEditGroupViewModel
    {
        [TextArea]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Nombre { get; set; }
    }
}