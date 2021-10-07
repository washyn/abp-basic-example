using Volo.Abp.AspNetCore.TestBase;
using Volo.Abp.Modularity;
using Washyn.Application;

namespace Washyn.Web.Tests
{
    [DependsOn(
        typeof(AbpAspNetCoreTestBaseModule),
        typeof(ApplicationModule),
        typeof(WebModule)
    )]
    public class Class1 : AbpModule
    {
    }
}