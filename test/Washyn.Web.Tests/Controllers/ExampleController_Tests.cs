using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Washyn.Application;
using Xunit;

namespace Washyn.Web.Tests.Controllers
{
    public class ExampleController_Tests : WebTestBase
    {
        [Fact]
        public async Task Test_ApiExample()
        {
            var response = await GetResponseAsObjectAsync<PagedResultDto<PruebaDto>>("/api/example");
            response.TotalCount.ShouldBe(1);
            response.Items.First().Nombre.ShouldContain("Dato desde seeder");
        }
    }
}