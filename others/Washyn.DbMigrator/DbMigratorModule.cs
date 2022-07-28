using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Washyn.Domain;
using Washyn.EntityFrameworkCore;

namespace Washyn.DbMigrator
{
    [DependsOn(typeof(DomainModule))]
    [DependsOn(typeof(EntityFrameworkCoreModule))]
    [DependsOn(typeof(AbpAutofacModule))]
    public class DbMigratorModule : AbpModule
    {
    }
}