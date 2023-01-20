using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Washyn.AdminLteTheme.Bundling
{
    [DependsOn(typeof(SharedThemeGlobalStyleContributor))]
    public class StyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.RemoveAll(x => x == (CultureHelper.IsRtl
                ? "/libs/bootstrap/css/bootstrap.rtl.css"
                : "/libs/bootstrap/css/bootstrap.css"));
        }
    }
}