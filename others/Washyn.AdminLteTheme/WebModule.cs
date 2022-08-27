using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Washyn.AdminLteTheme
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
    [DependsOn(typeof(AbpAutofacModule))] //Add dependency to ABP Autofac module
    public class WebModule : AbpModule
    {
        
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(WebModule).Assembly);
            });
        }


        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpThemingOptions>(options =>
            {
                options.Themes.Add<AdminLteTheme>();
            });
            
            Configure<AbpAntiForgeryOptions>(options =>
            {
                options.AutoValidate = false;
            });
        }


        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();
        
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            
            app.UseStaticFiles();
            app.UseRouting();
            app.UseConfiguredEndpoints();
        }
    }
}