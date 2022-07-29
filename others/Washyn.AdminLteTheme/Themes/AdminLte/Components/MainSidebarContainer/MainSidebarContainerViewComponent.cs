using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Washyn.AdminLteTheme.Themes.AdminLte.Components.MainSidebarContainer
{
    public class MainSidebarContainerViewComponent : AbpViewComponent
    {
        public MainSidebarContainerViewComponent()
        {
            
        }
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/AdminLte/Components/MainSidebarContainer/Default.cshtml");
        }
    }
}