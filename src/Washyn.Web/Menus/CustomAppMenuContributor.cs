using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Washyn.Web.Menus
{
    public class CustomAppMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }
        
        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            context.Menu.AddItem(new ApplicationMenuItem("MENU", "Crud display", "/Crud"));
            context.Menu.AddItem(new ApplicationMenuItem("MENU", "Example table page", "/ExampleTablePage"));
            // context.Menu.AddItem(new ApplicationMenuItem("TEST", "Test page", "/TestPage", icon:"plus"));
            // context.Menu.AddItem(new ApplicationMenuItem("TEST", "Test page", "/TestPage", icon:"plus"));
        }
    }
}