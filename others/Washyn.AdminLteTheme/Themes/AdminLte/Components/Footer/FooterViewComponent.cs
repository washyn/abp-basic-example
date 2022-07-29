using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Washyn.AdminLteTheme.Themes.AdminLte.Components.Footer
{
    public class FooterViewComponent : AbpViewComponent
    {

        public FooterViewComponent()
        {
            
        }
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/AdminLte/Components/Footer/Default.cshtml");
        }
    }
}