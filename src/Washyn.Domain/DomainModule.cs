using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Washyn.Domain
{
    [DependsOn(typeof(AbpDddDomainModule))]
    public class DomainModule : AbpModule
    {

    }

}
