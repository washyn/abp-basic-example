using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Modularity;

namespace Washyn.Web.Bundling.Select2
{
    [DependsOn(typeof(Select2BoostrapScriptContributor))]
    public class Select2FixScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/js/dom-event-handler-bootstrap.js");
        }
    }
}