using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Timing;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Washyn.Application;
using Washyn.Domain;
using Washyn.Domain.Localization;
using Washyn.EntityFrameworkCore;
using Washyn.Web.Menus;

namespace Washyn.Web
{
    [DependsOn(typeof(ApplicationModule))]
    [DependsOn(typeof(EntityFrameworkCoreModule))]
    [DependsOn(typeof(AbpAutofacModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcUiBundlingModule))]
    [DependsOn(typeof(AbpAutofacModule))]
    [DependsOn(typeof(AbpAspNetCoreSerilogModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcUiBasicThemeModule))]
    public class WebModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();
            
            Configure<AbpAuditingOptions>(options =>
            {
                options.IsEnabled = false; //Disables the auditing system
            });
            
            Configure<AbpBundlingOptions>(options =>
            {
            });
            
            Configure<AbpClockOptions>(options =>
            {
                options.Kind = DateTimeKind.Utc;
            });
            
            context.Services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/login";
                    options.LogoutPath = "/logout";
                    options.AccessDeniedPath = "/AccessDenied";
                });

            context.Services.AddHttpContextAccessor();
            
            ConfigureAutoApiControllers();
            ConfigureVirtualFileSystem(hostingEnvironment);
            ConfigureLocalizationServices();
            ConfigureNavigationServices();
        }

        #region Configurations

        private void ConfigureAutoApiControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options
                    .ConventionalControllers
                    .Create(typeof(ApplicationModule).Assembly);
            });
        }
        private void ConfigureNavigationServices()
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new CustomAppMenuContributor());
            });
        }
        
        private void ConfigureLocalizationServices()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("es-pe", "es-pe", "Español Peru"));
                options.Languages.Add(new LanguageInfo("es", "es", "Español"));
            });
        }

        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(
                    typeof(WashinResource),
                    typeof(DomainModule).Assembly,
                    typeof(ApplicationModule).Assembly,
                    typeof(WebModule).Assembly
                );
            });
        }
        
        private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<DomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Washyn.Domain"));
                    options.FileSets.ReplaceEmbeddedByPhysical<ApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Washyn.Application"));
                    options.FileSets.ReplaceEmbeddedByPhysical<WebModule>(hostingEnvironment.ContentRootPath);
                });
            }
        }
        
        #endregion
      
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
            app.UseAbpRequestLocalization();
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            
            app.UseRouting();
            
            app.UseAbpSerilogEnrichers();
            
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseConfiguredEndpoints();
        }
    }
}