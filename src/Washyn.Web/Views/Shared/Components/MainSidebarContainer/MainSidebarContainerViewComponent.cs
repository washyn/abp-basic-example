using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Washyn.Web.Views.Shared.Components.MainSidebarContainer
{
    public class MainSidebarContainerViewComponent : AbpViewComponent
    {
        public MainSidebarContainerViewComponent()
        {
            
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}