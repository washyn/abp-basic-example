using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Washyn.Web.Views.Shared.Components.Footer
{
    public class FooterViewComponent : AbpViewComponent
    {

        public FooterViewComponent()
        {
            
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}