using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Washyn.AdminLteTheme.Bundling;
using Washyn.AdminLteTheme.Toolbars;

namespace Washyn.AdminLteTheme
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(AbpAutofacModule))] //Add dependency to ABP Autofac module
    
    [DependsOn(typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcUiMultiTenancyModule))]
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
            
            Configure<AbpToolbarOptions>(options =>
            {
                options.Contributors.Add(new AdminLteThemeMainTopToolbarContributor());
            });
            
            // Configure<AbpAntiForgeryOptions>(options =>
            // {
            //     options.AutoValidate = false;
            // });
            
            Configure<AbpBundlingOptions>(options =>
            {
                options
                    .StyleBundles
                    .Add(CustomBundles.Styles.Global, bundle =>
                    {
                        bundle
                            .AddContributors(typeof(StyleContributor));
                    });

                options
                    .ScriptBundles
                    .Add(CustomBundles.Scripts.Global, bundle =>
                    {
                        bundle
                            .AddContributors(typeof(ScriptContributor));
                    });
            });
        }


        // public override void OnApplicationInitialization(ApplicationInitializationContext context)
        // {
        //     var app = context.GetApplicationBuilder();
        //     var env = context.GetEnvironment();
        //
        //     if (env.IsDevelopment())
        //     {
        //         app.UseDeveloperExceptionPage();
        //     }
        //     else
        //     {
        //         app.UseExceptionHandler("/Error");
        //     }
        //     
        //     app.UseStaticFiles();
        //     app.UseRouting();
        //     app.UseConfiguredEndpoints();
        // }
    }
}