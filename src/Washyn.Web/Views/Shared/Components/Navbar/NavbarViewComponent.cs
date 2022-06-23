using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Washyn.Web.Views.Shared.Components.Navbar
{
    public class NavbarViewComponent : AbpViewComponent
    {
        public NavbarViewComponent()
        {
            
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}