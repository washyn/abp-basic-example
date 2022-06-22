using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.Modularity;

namespace Washyn.Web.Bundling
{
    [DependsOn(
        // typeof(CoreScriptContributor)
        typeof(SharedThemeGlobalScriptContributor)
    )]
    public class ScriptContributor : BundleContributor
    {
        
    }
}