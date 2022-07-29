using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Washyn.AdminLteTheme.Themes.AdminLte.Components.ControlSidebar
{
    public class ControlSidebarViewComponent : AbpViewComponent
    {
        public ControlSidebarViewComponent()
        {
            
        }
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/AdminLte/Components/ControlSidebar/Default.cshtml");
        }
    }
}