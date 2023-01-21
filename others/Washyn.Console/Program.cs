using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Washyn.Application;
using Washyn.HttpApi.Client;

namespace Washyn.Console
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
#if DEBUG
                .MinimumLevel.Debug()
#else
                .MinimumLevel.Information()
#endif
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Async(c => c.File("Logs/logs.txt"))
#if DEBUG
                .WriteTo.Async(c => c.Console())
#endif
                .CreateLogger();

            try
            {
                Log.Information("Starting console host.");

                await Host.CreateDefaultBuilder(args)
                    .ConfigureServices(services =>
                    {
                        services.AddHostedService<BookStoreHostedService>();
                    })
                    .UseSerilog()
                    .RunConsoleAsync();

                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly!");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
    
    
    public class BookStoreHostedService : IHostedService
    {
        private IAbpApplicationWithInternalServiceProvider? _abpApplication;

        private readonly IConfiguration _configuration;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;

        public BookStoreHostedService(IConfiguration configuration, 
            IHostEnvironment hostEnvironment,
            IHostApplicationLifetime hostApplicationLifetime)
        {
            _configuration = configuration;
            _hostEnvironment = hostEnvironment;
            _hostApplicationLifetime = hostApplicationLifetime;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _abpApplication = AbpApplicationFactory.Create<ConsoleModule>(options =>
            {
                options.Services.ReplaceConfiguration(_configuration);
                options.Services.AddSingleton(_hostEnvironment);

                options.UseAutofac();
                options.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());
            });

            _abpApplication.Initialize();

            var logger = _abpApplication.ServiceProvider.GetRequiredService<ILogger<BookStoreHostedService>>();
            var appService = _abpApplication.ServiceProvider.GetRequiredService<IPruebaAppService>();

            var data = await appService.GetListAsync(new PagedAndSortedResultRequestDto());
            
            logger.LogInformation("----------------------------------------------------------------------");
            logger.LogInformation("remote data");
            foreach (var item in data.Items)
            {
                logger.LogInformation(item.Nombre);
            }
            logger.LogInformation("----------------------------------------------------------------------");
            
            _abpApplication.Shutdown();
            _hostApplicationLifetime.StopApplication();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _abpApplication?.Shutdown();
        }
    }

    [DependsOn(typeof(AbpAutofacModule))]
    [DependsOn(typeof(HttpApiClientModule))]
    public class ConsoleModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpRemoteServiceOptions>(options =>
            {
                options.RemoteServices.Default = new RemoteServiceConfiguration("https://localhost:5001/");
            });
        }
    }
}
