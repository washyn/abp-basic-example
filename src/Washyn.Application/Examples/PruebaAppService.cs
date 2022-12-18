using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Washyn.Domain;

namespace Washyn.Application
{
    
    public class PruebaAppService : CrudAppService<Prueba, PruebaDto, long, PruebaFilterInput>,IPruebaAppService
    {
        public PruebaAppService(IRepository<Prueba, long> repository) : base(repository)
        {
        }

        protected override async Task<IQueryable<Prueba>> CreateFilteredQueryAsync(PruebaFilterInput input)
        {
            var queryable  = await base.CreateFilteredQueryAsync(input);
            return queryable.WhereIf(!string.IsNullOrEmpty(input.Filter),
                prueba => prueba.Nombre.Contains(input.Filter));
        }
    }
}