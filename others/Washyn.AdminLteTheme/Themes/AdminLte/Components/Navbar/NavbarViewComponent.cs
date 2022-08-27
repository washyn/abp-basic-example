using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Washyn.AdminLteTheme.Themes.AdminLte.Components.Navbar
{
    public class NavbarViewComponent : AbpViewComponent
    {
        public NavbarViewComponent()
        {
            
        }
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/AdminLte/Components/Navbar/OriginalSection.cshtml");
        }
    }
}