using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Washyn.Web.Tests
{
    public class WebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<WebTestModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
}