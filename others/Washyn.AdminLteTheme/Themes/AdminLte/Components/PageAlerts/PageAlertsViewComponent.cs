using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Alerts;

namespace Washyn.AdminLteTheme.Themes.AdminLte.Components.PageAlerts
{
    public class PageAlertsViewComponent : ViewComponent
    {
        private readonly IAlertManager _alertManager;

        public PageAlertsViewComponent(IAlertManager alertManager)
        {
            _alertManager = alertManager;
        }
        
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/AdminLte/Components/PageAlerts/Default.cshtml", _alertManager.Alerts);
        }
    }
}