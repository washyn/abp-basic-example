using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Washyn.Domain;

namespace Washyn.Application
{
    public class PruebaAppService : CrudAppService<Prueba, PruebaDto, long>,IPruebaAppService
    {
        public PruebaAppService(IRepository<Prueba, long> repository) : base(repository)
        {
        }
    }
}