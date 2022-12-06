using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Washyn.Application;
using Xunit;

namespace Washyn.Tests.EfCore.Prueba
{
    public class PruebaRepositoryTests: AppTestBase
    {
        private readonly IRepository<Domain.Prueba, long> _pruebaRepository;
        
        public PruebaRepositoryTests()
        {
            _pruebaRepository = GetRequiredService<IRepository<Domain.Prueba, long>>();
        }

        // TODO: revisar si es normal que los seeds de la app tambien se inserten en los tests.
        [Fact]
        public async Task GetItems()
        {
            const string defaultDataSeedVal = "Dato desde seeder";
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var res = await _pruebaRepository.GetListAsync();
                var secondVal = await _pruebaRepository.FirstOrDefaultAsync(a => a.Nombre == defaultDataSeedVal);
                // Assert
                res.Count.ShouldBe(1);
                res.First().Nombre.ShouldBe(defaultDataSeedVal);
                
                secondVal.Nombre.ShouldContain(defaultDataSeedVal);
            });
        }
    }
}