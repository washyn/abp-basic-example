using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
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
        
        private SqliteConnection _sqliteConnection;
        
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            base.PreConfigureServices(context);
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            // AbpBackgroundJobOptions, not exists
            // context.Services.AddAlwaysAllowAuthorization();
            
            ConfigureInMemorySqlite(context.Services);
        }



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

        public override void OnApplicationShutdown(ApplicationShutdownContext context)
        {
            _sqliteConnection.Dispose();
        }

        private void ConfigureInMemorySqlite(IServiceCollection serviceCollection)
        {
            _sqliteConnection = CreateDatabaseAndGetConnection();
            serviceCollection.Configure<AbpDbContextOptions>(options =>
            {
                options.Configure(context =>
                {
                    context.DbContextOptions.UseSqlite(_sqliteConnection);
                });
            });
        }
        
        private static SqliteConnection CreateDatabaseAndGetConnection()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<EntityFrameworkCoreDbContext>()
                .UseSqlite(connection)
                .Options;
            using (var context = new EntityFrameworkCoreDbContext(options))
            {
                context.GetService<IRelationalDatabaseCreator>()
                    .CreateTables();
            }

            return connection;
        }
    }
}