using Volo.Abp.AspNetCore.TestBase;
using Volo.Abp.Modularity;
using Washyn.Application;

namespace Washyn.Web.Tests
{
    [DependsOn(
        typeof(ApplicationModule),
        typeof(WebModule),
        
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class WebTestModule : AbpModule
    {
        // This for test, web layer, for razor pages or
    }
}