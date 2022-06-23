using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Washyn.Web.Views.Shared.Components.ControlSidebar
{
    public class ControlSidebarViewComponent : AbpViewComponent
    {
        public ControlSidebarViewComponent()
        {
            
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}