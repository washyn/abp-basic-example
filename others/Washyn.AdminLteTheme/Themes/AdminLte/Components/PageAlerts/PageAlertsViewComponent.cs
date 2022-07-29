using Microsoft.AspNetCore.Mvc;

namespace Washyn.AdminLteTheme.Themes.AdminLte.Components.PageAlerts
{
    public class PageAlertsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/AdminLte/Components/PageAlerts/Default.cshtml");
        }
    }
}