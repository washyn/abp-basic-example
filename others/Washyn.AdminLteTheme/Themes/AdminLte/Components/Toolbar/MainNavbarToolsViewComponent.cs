using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;

namespace Washyn.AdminLteTheme.Themes.AdminLte.Components.Toolbar
{
    public class MainNavbarToolsViewComponent : AbpViewComponent
    {
        private readonly IToolbarManager _toolbarManager;

        public MainNavbarToolsViewComponent(IToolbarManager toolbarManager)
        {
            _toolbarManager = toolbarManager;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var toolbar = await _toolbarManager.GetAsync(StandardToolbars.Main);
            return View("~/Themes/AdminLte/Components/Toolbar/Default.cshtml", toolbar);
        }
    }
}