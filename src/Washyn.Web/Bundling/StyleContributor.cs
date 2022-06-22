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
        
    }
}