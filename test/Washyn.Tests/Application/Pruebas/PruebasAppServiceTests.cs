using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Washyn.Application;
using Washyn.Domain;
using Xunit;

namespace Washyn.Tests.Application.Pruebas
{
    public class PruebasAppServiceTests : AppTestBase
    {
        private readonly IRepository<Prueba, long> _pruebasRepository;
        private readonly IPruebaAppService _pruebaAppService;
        public PruebasAppServiceTests()
        {
            _pruebasRepository = GetRequiredService<IRepository<Prueba, long>>();
            _pruebaAppService = GetRequiredService<IPruebaAppService>();
        }
        
        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _pruebaAppService.GetListAsync(new PruebaFilterInput());
        
            // Assert
            result.TotalCount.ShouldBe(1);
            result.Items.Any(x => x.Id == 1).ShouldBe(true);
        }
        
        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _pruebaAppService.GetAsync(1);
            // Assert
            result.ShouldNotBeNull();
            result.Nombre.ShouldBe("Dato desde seeder");
        }
        
        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new PruebaDto()
            {
                Nombre = "test data"
            };
        
            // Act
            var serviceResult = await _pruebaAppService.CreateAsync(input);
        
            // Assert
            var result = await _pruebasRepository.FindAsync(c => c.Id == serviceResult.Id);
        
            result.ShouldNotBe(null);
            result.Nombre.ShouldBe("test data");
        }
        
        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new PruebaDto()
            {
                Nombre = "eb6b966f00be4bf395a8a744396",
            };
        
            // Act
            var serviceResult = await _pruebaAppService.UpdateAsync(1, input);
        
            // Assert
            var result = await _pruebasRepository.FindAsync(c => c.Id == serviceResult.Id);
        
            result.ShouldNotBe(null);
            result.Nombre.ShouldBe("eb6b966f00be4bf395a8a744396");
        }
        
        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _pruebaAppService.DeleteAsync(1);
        
            // Assert
            var result = await _pruebasRepository.FindAsync(c => c.Id == 1);
        
            result.ShouldBeNull();
        }
        
    }
}