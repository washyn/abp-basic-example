using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Washyn.Domain.Data;

namespace Washyn.DbMigrator
{
    public class DbMigratorHostedService : IHostedService
    {
        private readonly IHostApplicationLifetime _applicationLifetime;
        private readonly IConfiguration _configuration;

        public DbMigratorHostedService(IHostApplicationLifetime applicationLifetime,
            IConfiguration configuration)
        {
            _applicationLifetime = applicationLifetime;
            _configuration = configuration;
        }
        
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var app = AbpApplicationFactory
                       .Create<DbMigratorModule>(option =>
                       {
                           option.Services.ReplaceConfiguration(_configuration);
                           option.UseAutofac();
                           option.Services.AddLogging(builder => builder.AddSerilog());
                       }))
            {
                app.Initialize();
                
                await app
                    .ServiceProvider
                    .GetRequiredService<DbMigrationService>()
                    .MigrateAsync();
                
                app.Shutdown();
                _applicationLifetime.StopApplication();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}