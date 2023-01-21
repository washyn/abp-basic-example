using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Washyn.Application;

namespace Washyn.HttpApi.Client
{
    [DependsOn(typeof(ApplicationModule))]
    [DependsOn(typeof(AbpHttpClientModule))]
    public class HttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ApplicationModule).Assembly,
                RemoteServiceName
            );
        }
    }
}