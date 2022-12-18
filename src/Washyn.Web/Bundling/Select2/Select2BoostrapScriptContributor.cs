using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.Select2;
using Volo.Abp.Modularity;

namespace Washyn.Web.Bundling.Select2
{
    [DependsOn(typeof(Select2ScriptContributor))]
    public class Select2BoostrapScriptContributor : BundleContributor
    {
        
    }
}