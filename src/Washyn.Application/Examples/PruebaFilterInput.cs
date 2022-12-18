using Volo.Abp.Application.Dtos;

namespace Washyn.Application
{
    public class PruebaFilterInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}