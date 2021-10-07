using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;
using Washyn.Application;
using Washyn.EntityFrameworkCore;

namespace Washyn.Tests
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(EntityFrameworkCoreModule),
        typeof(ApplicationModule),
        typeof(AbpTestBaseModule),
        typeof(AbpEntityFrameworkCoreSqliteModule)
    )]
    public class Class1 : AbpModule
    {
    }
}