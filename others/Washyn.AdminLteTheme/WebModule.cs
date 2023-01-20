using EasyAbp.Abp.SettingUi;
using EasyAbp.Abp.SettingUi.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.FeatureManagement;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Identity.Web;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.IdentityServer;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.Web;
using Volo.Abp.Swashbuckle;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.Web;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Washyn.AdminLteTheme.Bundling;
using Washyn.AdminLteTheme.Data;
using Washyn.AdminLteTheme.Toolbars;
using Washyn.Internet.Menus;

namespace Washyn.AdminLteTheme
{
    
    
    [DependsOn(
        
        // ABP Framework packages
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(AbpSwashbuckleModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(AbpAspNetCoreSerilogModule),
        // typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        
        // typeof(WebModule),
        
        // typeof(AbpAspNetCoreMvcUiLeptonThemeModule),

        // Account module packages
        typeof(AbpAccountApplicationModule),
        typeof(AbpAccountHttpApiModule),
        typeof(AbpAccountWebIdentityServerModule),

        // Identity module packages
        typeof(AbpPermissionManagementDomainIdentityModule),
        typeof(AbpPermissionManagementDomainIdentityServerModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpIdentityHttpApiModule),
        typeof(AbpIdentityEntityFrameworkCoreModule),
        typeof(AbpIdentityServerEntityFrameworkCoreModule),
        typeof(AbpIdentityWebModule),

        // Audit logging module packages
        typeof(AbpAuditLoggingEntityFrameworkCoreModule),

        // Permission Management module packages
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpPermissionManagementHttpApiModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule),

        // Tenant Management module packages
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpTenantManagementHttpApiModule),
        typeof(AbpTenantManagementEntityFrameworkCoreModule),
        typeof(AbpTenantManagementWebModule),

        // Feature Management module packages
        typeof(AbpFeatureManagementApplicationModule),
        typeof(AbpFeatureManagementEntityFrameworkCoreModule),
        typeof(AbpFeatureManagementHttpApiModule),
        typeof(AbpFeatureManagementWebModule),

        // Setting Management module packages
        typeof(AbpSettingManagementApplicationModule),
        typeof(AbpSettingManagementEntityFrameworkCoreModule),
        typeof(AbpSettingManagementHttpApiModule),
        typeof(AbpSettingManagementWebModule),
        
        // Settings UI modules
        typeof(AbpSettingUiApplicationModule),
        typeof(AbpSettingUiApplicationContractsModule),
        typeof(AbpSettingUiDomainSharedModule),
        typeof(AbpSettingUiHttpApiModule),
        typeof(AbpSettingUiWebModule)

    )]
        
    
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(AbpAutofacModule))] //Add dependency to ABP Autofac module
    [DependsOn(typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcUiMultiTenancyModule))]
    // [DependsOn(typeof(AbpAspNetCoreMvcUiBasicThemeModule))]
    public class WebModule : AbpModule
    {
        
        // public override void PreConfigureServices(ServiceConfigurationContext context)
        // {
        //     PreConfigure<IMvcBuilder>(mvcBuilder =>
        //     {
        //         mvcBuilder.AddApplicationPartIfNotExists(typeof(WebModule).Assembly);
        //     });
        // }


        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();
            
            Configure<AbpThemingOptions>(options =>
            {
                options.Themes.Add<AdminLteTheme>();
            });
            
            Configure<AbpToolbarOptions>(options =>
            {
                options.Contributors.Add(new AdminLteThemeMainTopToolbarContributor());
            });
            
            Configure<AbpBundlingOptions>(options =>
            {
                // options
                //     .StyleBundles
                //     .Add(StandardBundles.Styles.Global, bundle =>
                //     {
                //         bundle
                //             .AddContributors(typeof(StyleContributor));
                //     });
                //
                // options
                //     .ScriptBundles
                //     .Add(StandardBundles.Scripts.Global, bundle =>
                //     {
                //         bundle
                //             .AddContributors(typeof(ScriptContributor));
                //     });
            });
            
            
            ConfigureMultiTenancy();
            // ConfigureUrls(configuration);
            ConfigureBundles();
            ConfigureAuthentication(context, configuration);
            ConfigureAutoMapper();
            // ConfigureVirtualFileSystem(hostingEnvironment);
            ConfigureLocalizationServices();
            ConfigureNavigationServices();
            // ConfigureAutoApiControllers();
            ConfigureSwaggerServices(context.Services);
            ConfigureEfCore(context);
            
        }

        #region Configs

        
        private void ConfigureMultiTenancy()
        {
            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = false;
            });
        }

        private void ConfigureBundles()
        {
            Configure<AbpBundlingOptions>(options =>
            {
                // options.StyleBundles.Configure(
                //     BasicThemeBundles.Styles.Global,
                //     bundle =>
                //     {
                //         bundle.AddFiles("/global-styles.css");
                //     }
                // );
            });
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                    options.Audience = "Internet";
                });
        }

        private void ConfigureAutoMapper()
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                // options.AddMaps<InternetWebModule>();
            });
        }

        private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<WebModule>();
                if (hostingEnvironment.IsDevelopment())
                {
                    /* Using physical files in development, so we don't need to recompile on changes */
                    options.FileSets.ReplaceEmbeddedByPhysical<WebModule>(hostingEnvironment.ContentRootPath);
                }
            });
        }
        
        // private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
        // {
        //     Configure<AbpVirtualFileSystemOptions>(options =>
        //     {
        //         options.FileSets.AddEmbedded<InternetModule>();
        //
        //         if (hostingEnvironment.IsDevelopment())
        //         {
        //             // options.FileSets.ReplaceEmbeddedByPhysical<InternetModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}Washyn.Internet", Path.DirectorySeparatorChar)));
        //             options.FileSets.ReplaceEmbeddedByPhysical<InternetModule>(hostingEnvironment.ContentRootPath);
        //         }
        //     });
        // }


        private void ConfigureLocalizationServices()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
                options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
                options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
                options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish"));
                options.Languages.Add(new LanguageInfo("fr", "fr", "Français"));
                options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi", "in"));
                options.Languages.Add(new LanguageInfo("it", "it", "Italian", "it"));
                options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
                options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
                options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak"));
                options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
                options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
                options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch", "de"));
                options.Languages.Add(new LanguageInfo("es", "es", "Español"));
            });
        }

        private void ConfigureNavigationServices()
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new InternetMenuContributor());
            });
        }

        private void ConfigureAutoApiControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(WebModule).Assembly);
            });
        }

        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddAbpSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Internet API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                }
            );
        }
        
        private void ConfigureEfCore(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<InternetDbContext>(options =>
            {
                /* You can remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots
                 * Documentation: https://docs.abp.io/en/abp/latest/Entity-Framework-Core#add-default-repositories
                 */
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.Configure(configurationContext =>
                {
                    configurationContext.UseSqlServer();
                });
            });
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

            app.UseAbpRequestLocalization();

            if (!env.IsDevelopment())
            {
                app.UseErrorPage();
            }

            app.UseCorrelationId();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseJwtTokenMiddleware();

            if (false)
            {
                app.UseMultiTenancy();
            }

            app.UseUnitOfWork();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseAbpSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Internet API");
            });
            app.UseAuditing();
            app.UseAbpSerilogEnrichers();
            app.UseConfiguredEndpoints();
        }
    }
}