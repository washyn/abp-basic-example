using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using Volo.Abp.AspNetCore.TestBase;
using Volo.Abp.Modularity;
using Washyn.Application;
using Washyn.Domain;
using Washyn.Tests;

namespace Washyn.Web.Tests
{
    [DependsOn(
        typeof(WebModule),
        typeof(CoreTestModule),        
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class WebTestModule : AbpModule
    {
        // This for test, web layer, for razor pages or

        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", false);
            builder.AddJsonFile("appsettings.secrets.json", true);
            context.Services.ReplaceConfiguration(builder.Build());

            context.Services.PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.PartManager.ApplicationParts.Add(new AssemblyPart(typeof(WebModule).Assembly));
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureLocalizationServices(context.Services);
        }

        #region Configurations

        private static void ConfigureLocalizationServices(IServiceCollection serviceCollection)
        {
            var cultures = new List<CultureInfo>() { new CultureInfo("en"), new CultureInfo("es") };

            serviceCollection.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("es");
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });
        }

        #endregion
    }
}