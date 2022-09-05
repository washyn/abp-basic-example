using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using Volo.Abp;
using Volo.Abp.AspNetCore;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.ApplicationConfigurations;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client;
using Volo.Abp.Localization;
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
        //typeof(AbpHttpClientModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAspNetCoreMvcUiBundlingModule),
        typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
    [DependsOn(typeof(AbpAutofacModule))]
    [DependsOn(typeof(AbpAspNetCoreSerilogModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcUiBasicThemeModule))]
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

            context.Services.AddRazorPages();
            ConfigureLocalizationServices();
            
            // TODO: configure clock kind, to Peru UTC - 5
            
            //////////////////////////////
            CultureInfo[] supportedCultures = new[]
            {
                new CultureInfo("es-pe"),
                new CultureInfo("ar"),
                new CultureInfo("en")
            };

            context.Services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("es-pe");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider(),
                };
            });
            /////////////////////////////////
            
        }
        
        // use with abp request localization
        private void ConfigureLocalizationServices()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                // options.Languages.Add(new LanguageInfo("en", "en", "English"));
                // options.Languages.Add(new LanguageInfo("es-pe", "es-pe", "Español Peru"));
                // options.Languages.Add(new LanguageInfo("es", "es", "Español"));
            });
            
            // CultureInfo.CurrentCulture = new CultureInfo("es-pe");
        }
        
        // this for get html culture
        // document.documentElement.lang
        // this return es-pe en or empty
        // in this case use default lang browser
        
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

            // This works with AbpLocalizationOptions
            // app.UseAbpRequestLocalization();
            app.UseRequestLocalization();
            
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            // app.UseAuthentication();
            // app.UseUnitOfWork();
            // app.UseAuthorization();
            // app.UseAuditing(); ??? midleware de audit, escribe en el logger o ayuda a en logs de base de datos 
            app.UseAbpSerilogEnrichers();
            
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}