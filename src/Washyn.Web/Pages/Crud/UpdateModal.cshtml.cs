using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Washyn.Application;

namespace Washyn.Web.Pages.Crud
{
    public class UpdateModal : AbpPageModel
    {

        [BindProperty(SupportsGet = true)]
        [HiddenInput]
        public long Id { get; set; }

        [BindProperty] public CreateEditGroupViewModel ViewModel { get; set; }
        [Inject] public IPruebaAppService PruebaAppService { get; set; }


        public virtual async Task OnGetAsync()
        {
            var dto = await PruebaAppService.GetAsync(Id);
            
            ViewModel = new CreateEditGroupViewModel()
            {
                Nombre = dto.Nombre
            };
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            await PruebaAppService.UpdateAsync(Id, new PruebaDto()
            {
                Nombre = ViewModel.Nombre
            });
            return NoContent();
        }
    }
}