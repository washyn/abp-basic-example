using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NUglify.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Pagination;
using Washyn.Application;

namespace Washyn.Web.Pages
{
    public class ExampleTablePage : PageModel
    {
        
        // sorting: "id asc"
        // skipCount: 
        // 0
        // maxResultCount: 
        // 10
        // @* <a tabindex="-1" class="page-link" href="/Components/Paginator?currentPage=10&amp;sort=id asc">10</a> *@
        // el back puede recibir esto
        // https://localhost:5001/Components/Paginator?
        // currentPage=9
        // sort=id%20asc
        
        // from url
        // var currentPage = 1;
        // from url
        // var sort = "id asc";
        // var pagerModel = new PagerModel(100, 10, currentPage, 10, "/Components/Paginator", sort);

        [Inject]
        public IPruebaAppService AppService { get; set; }
        
        [Inject]
        public ILogger<ExampleTablePage> Logger { get; set; }

        
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        
        [BindProperty(SupportsGet = true)]
        public string Filter { get; set; }
        
        public PagedResultDto<PruebaDto> List { get; set; }
        public const int PageSize = 2;
        // this an example of default way for use this
        // public PagerModel PagerModelInfo => new PagerModel(List.TotalCount, List.Items.Count, CurrentPage, PageSize, "/ExampleTablePage");
        public PagerModel PagerModelInfo => new PagerModel(List.TotalCount, List.Items.Count, CurrentPage, PageSize, $"{Request.Path.ToString()}?filter={Filter}");
        public async Task OnGetAsync()
        {
            List = await AppService.GetListAsync(new PruebaFilterInput()
            {
                Sorting = "id desc",
                MaxResultCount = PageSize,
                SkipCount = PageSize * (CurrentPage - 1),                 // menos 1 porque inicia la pagina en 0
                Filter = Filter
            });
        }
    }
}