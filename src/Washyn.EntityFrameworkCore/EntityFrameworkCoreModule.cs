using Volo.Abp.Modularity;
using Washyn.Domain;

namespace Washyn.EntityFrameworkCore
{
    [DependsOn(typeof(DomainModule))]
    public class EntityFrameworkCoreModule : AbpModule
    {

    }
}
