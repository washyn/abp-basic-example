using Microsoft.AspNetCore.Mvc;

namespace Washyn.AdminLteTheme.Themes.AdminLte.Components.Brand
{
    public class BrandLogoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/AdminLte/Components/Brand/Default.cshtml");
        }
    }
}