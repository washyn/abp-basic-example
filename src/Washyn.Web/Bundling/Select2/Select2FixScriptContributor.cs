using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Washyn.Web.Bundling.Select2
{
    [DependsOn(typeof(Select2BoostrapScriptContributor))]
    public class Select2FixScriptContributor : BundleContributor
    {
        public const string PackageName = "select2";
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/js/dom-event-handler-bootstrap.js");
            context.Files.AddIfNotContains("/js/select2-autofocus-fix.js");
        }
        
        public override void ConfigureDynamicResources(BundleConfigurationContext context)
        {
            var fileName = context.LazyServiceProvider
                .LazyGetRequiredService<IOptions<AbpLocalizationOptions>>()
                .Value
                .GetCurrentUICultureLanguageFilesMap(PackageName);
            var filePath = $"/libs/select2/js/i18n/{fileName}.js";
            if (context.FileProvider.GetFileInfo(filePath).Exists)
            {
                context.Files.AddIfNotContains(filePath);
            }
        }
    }
}