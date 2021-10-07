using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Washyn.Domain;

namespace Washyn.Application
{
    [DependsOn(typeof(DomainModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpDddApplicationModule))]
    public class ApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<ApplicationModule>();
            });
        }
    }
}
