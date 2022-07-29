using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Washyn.AdminLteTheme
{
    [Dependency(ReplaceServices = true)]
    public class CustomAppBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Custom brand prov";
    }
}