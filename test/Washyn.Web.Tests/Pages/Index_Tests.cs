using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Washyn.Web.Tests.Pages
{
    public class Index_Tests : WebTestBase
    {
        [Fact]
        public async Task Index_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
            response.ShouldContain("Welcome");
        }
    }
}