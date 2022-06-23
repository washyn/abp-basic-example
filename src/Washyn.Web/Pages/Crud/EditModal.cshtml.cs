using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Washyn.Application;

namespace Washyn.Web.Pages.Crud
{
    public class EditModal : PageModel
    {
        private readonly IPruebaAppService _pruebaAppService;

        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public long Id { get; set; }

        [BindProperty]
        public EditViewModal ViewModel { get; set; }

        // private readonly IEnrollmentAppService _service;

        public EditModal(
            // IEnrollmentAppService service
            IPruebaAppService pruebaAppService
            )
        {
            _pruebaAppService = pruebaAppService;
            // _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _pruebaAppService.GetAsync(Id);
            ViewModel = new EditViewModal() { Id = dto.Id, Nombre = dto.Nombre };
        }
        
        public virtual async Task<IActionResult> OnPostAsync()
        {
            // var dto = ObjectMapper.Map<CreateEditEnrollmentViewModel, CreateUpdateEnrollmentDto>(ViewModel);
            await _pruebaAppService.UpdateAsync(Id, new PruebaDto()
            {
                Id = ViewModel.Id,
                Nombre = ViewModel.Nombre,
            });
            return new NoContentResult();
        }
    }

    public class EditViewModal
    {
        [HiddenInput]
        public long Id { get; set; }
        public string Nombre { get; set; }
    }
}