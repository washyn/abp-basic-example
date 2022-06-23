using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Washyn.Application;

namespace Washyn.Web.Pages.Crud
{
    public class CreateModal : PageModel
    {
        private readonly IPruebaAppService _pruebaAppService;

        [BindProperty]
        public CreateViewModel ViewModel { get; set; }

        // private readonly IEnrollmentAppService _service;

        public CreateModal(IPruebaAppService pruebaAppService)
        {
            _pruebaAppService = pruebaAppService;
            // _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            // var dto = ObjectMapper.Map<CreateEditEnrollmentViewModel, CreateUpdateEnrollmentDto>(ViewModel);
            // await _service.CreateAsync(dto);
            // return NoContent();
            await _pruebaAppService.CreateAsync(new PruebaDto() { Nombre = ViewModel.Nombre });
            return new NoContentResult();
        }
    }

    public class CreateViewModel
    {
        public string Nombre { get; set; }
    }
}