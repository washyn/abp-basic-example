using Volo.Abp.Domain;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Washyn.Domain.Localization;

namespace Washyn.Domain
{
    [DependsOn(typeof(AbpDddDomainModule))]
    public class DomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);
            
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<DomainModule>();
            });
            
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Add<WashinResource>("es")
                    .AddVirtualJson("/Localization/Washin");
                options.DefaultResourceType = typeof(WashinResource);
            });
            
            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("Washyn", typeof(WashinResource));
            });
        }
    }
}
