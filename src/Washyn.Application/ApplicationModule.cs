using Volo.Abp.Modularity;
using Washyn.Domain;

namespace Washyn.Application
{
    [DependsOn(typeof(DomainModule))]
    public class ApplicationModule : AbpModule
    {

    }
}
