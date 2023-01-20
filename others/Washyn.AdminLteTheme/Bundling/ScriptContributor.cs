using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Washyn.AdminLteTheme.Bundling
{
    [DependsOn(typeof(SharedThemeGlobalScriptContributor))]
    public class ScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
        }
    }
}