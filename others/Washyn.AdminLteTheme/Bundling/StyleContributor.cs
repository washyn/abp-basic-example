using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.Modularity;

namespace Washyn.AdminLteTheme.Bundling
{
    [DependsOn(typeof(SharedThemeGlobalStyleContributor))]
    public class StyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            base.ConfigureBundle(context);
            // Check how this works best
            // boostrap sobreescribe detalles de ui del adminlte
            // context.Files.Remove("/libs/bootstrap/css/bootstrap.css");
        }
    }
}