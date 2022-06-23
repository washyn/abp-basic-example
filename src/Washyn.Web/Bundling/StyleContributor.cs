using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;

namespace Washyn.Web.Bundling
{
    [DependsOn(
        // typeof(CoreStyleContributor)
        typeof(SharedThemeGlobalStyleContributor)
    )]
    public class StyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            base.ConfigureBundle(context);
            // Check how this works best
            // context.Files.Remove("/libs/bootstrap/css/bootstrap.css");
        }
    }
}