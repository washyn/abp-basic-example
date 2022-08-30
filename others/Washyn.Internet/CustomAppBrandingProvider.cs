using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Washyn.Internet
{
    [Dependency(ReplaceServices = true)]
    public class CustomAppBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Internet";
    }
}