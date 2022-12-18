using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.Select2;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Washyn.Web.Bundling.Select2
{
    [DependsOn(typeof(Select2StyleContributor))]
    public class Select2BoostrapStyleContributor : BundleContributor
    {
        // public const string PackageName = "jquery-validation";
        
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/libs/select2-bootstrap4-theme/dist/select2-bootstrap4.css");
        }
        
        // TODO: add
        public override void ConfigureDynamicResources(BundleConfigurationContext context)
        {
            // var fileName = context.LazyServiceProvider.LazyGetRequiredService<IOptions<AbpLocalizationOptions>>().Value.GetCurrentUICultureLanguageFilesMap(PackageName);
            // var filePath = $"/libs/jquery-validation/localization/messages_{fileName}.js";
            // if (context.FileProvider.GetFileInfo(filePath).Exists)
            // {
            //     context.Files.AddIfNotContains(filePath);
            // }
        }
    }

}