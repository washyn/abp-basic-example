using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Washyn.Domain.Examples
{
    public class PruebaDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Prueba, long> _pruebaRepository;

        public PruebaDataSeedContributor(IRepository<Prueba, long> pruebaRepository)
        {
            _pruebaRepository = pruebaRepository;
        }
        
        public async Task SeedAsync(DataSeedContext context)
        {
            var record = new Prueba(1, "Dato desde seeder");
            // if (! await ExistRecord(record.Nombre))
            {
                await _pruebaRepository.InsertAsync(record, true);
            }
        }

        private async Task<bool> ExistRecord(string nombre)
        {
            var res = await _pruebaRepository.AnyAsync(a => a.Nombre == nombre);
            return res;
        }
    }
}