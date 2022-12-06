using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Washyn.Application;

namespace Washyn.Web.Controllers
{
    // [RemoteService(Name = IdentityRemoteServiceConsts.RemoteServiceName)]
    // [Area(IdentityRemoteServiceConsts.ModuleName)]
    // [ControllerName("Example")]
    [Route("api/example")]
    public class ExampleController: AbpController, IPruebaAppService
    {
        private readonly IPruebaAppService _pruebaAppService;

        public ExampleController(IPruebaAppService pruebaAppService)
        {
            _pruebaAppService = pruebaAppService;
        }
        
        [HttpGet]
        [Route("{id}")]
        public Task<PruebaDto> GetAsync(long id)
        {
            return _pruebaAppService.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<PruebaDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return _pruebaAppService.GetListAsync(input);
        }

        [HttpPost]
        public Task<PruebaDto> CreateAsync(PruebaDto input)
        {
            return _pruebaAppService.CreateAsync(input);
        }
        
        [HttpPut]
        [Route("{id}")]
        public Task<PruebaDto> UpdateAsync(long id, PruebaDto input)
        {
            return _pruebaAppService.UpdateAsync(id, input);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(long id)
        {
            return _pruebaAppService.DeleteAsync(id);
        }
    }
}