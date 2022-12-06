using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;
using Washyn.Application;
using Washyn.EntityFrameworkCore;

namespace Washyn.Tests
{
    [DependsOn(
        typeof(EntityFrameworkCoreModule),
        typeof(ApplicationModule),

        typeof(AbpAutofacModule),
        typeof(AbpTestBaseModule),
        typeof(AbpEntityFrameworkCoreSqliteModule)
    )]
    public class CoreTestModule : AbpModule
    {
        // This for test layers
        // Application
        // Domain
        // EntityFrameworkCore

        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            base.PreConfigureServices(context);
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            // AbpBackgroundJobOptions, not exists
            // context.Services.AddAlwaysAllowAuthorization();
        }

        #region MyRegion

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            SeedTestData(context);
        }

        private static void SeedTestData(ApplicationInitializationContext context)
        {
            AsyncHelper.RunSync(async () =>
            {
                using (var scope = context.ServiceProvider.CreateScope())
                {
                    await scope.ServiceProvider
                        .GetRequiredService<IDataSeeder>()
                        .SeedAsync();
                }
            });
        }

        #endregion
    }
}