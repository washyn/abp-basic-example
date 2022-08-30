using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.UI.Navigation;

namespace Washyn.AdminLteTheme.Themes.AdminLte.Components.MainMenu
{
    public class MainMenuViewComponent : AbpViewComponent
    {
        private readonly IMenuManager _menuManager;

        public MainMenuViewComponent(IMenuManager menuManager)
        {
            _menuManager = menuManager;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menu = await _menuManager.GetMainMenuAsync();
            return View("~/Themes/AdminLte/Components/MainMenu/Default.cshtml", menu);
        }
    }
}