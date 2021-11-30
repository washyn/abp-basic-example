using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Washyn.Application;
using Washyn.EntityFrameworkCore;

namespace Washyn.Web
{
    [DependsOn(
        typeof(ApplicationModule),
        typeof(EntityFrameworkCoreModule),
        typeof(AbpAutofacModule),
        typeof(AbpHttpClientModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAspNetCoreMvcUiBundlingModule),
        typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
    [DependsOn(typeof(AbpAutofacModule))]
    public class WebModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            context.Services.AddControllersWithViews();

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<WebModule>("Washyn.Web");
            });

            // for generate proxy for app services
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options
                    .ConventionalControllers
                    .Create(typeof(ApplicationModule).Assembly);
            });

            Configure<AbpAuditingOptions>(options =>
            {
                options.IsEnabled = false; //Disables the auditing system
            });


            // context.Services.AddHttpClientProxies(
            //     typeof(ApplicationModule).Assembly,
            //     asDefaultServices: false
            // );


            // Configure<DynamicJavaScriptProxyOptions>(options => {
            //     options.EnabledModules.Add("identity");
            // });


            Configure<AbpBundlingOptions>(options =>
            {
                // options
                //     .StyleBundles
                //     .Add(BasicThemeBundles.Styles.Global, bundle =>
                //     {
                //         bundle
                //             .AddBaseBundles(StandardBundles.Styles.Global)
                //             .AddContributors(typeof(BasicThemeGlobalStyleContributor));
                //     });
                //
                // options
                //     .ScriptBundles
                //     .Add(BasicThemeBundles.Scripts.Global, bundle =>
                //     {
                //         bundle
                //             .AddBaseBundles(StandardBundles.Scripts.Global)
                //             .AddContributors(typeof(BasicThemeGlobalScriptContributor));
                //     });
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}