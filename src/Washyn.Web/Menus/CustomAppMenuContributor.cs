using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
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
            var serviceAuth = context.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
            var isAutenticated = serviceAuth.HttpContext != null && 
                                 serviceAuth.HttpContext.User.Identity != null &&
                                 serviceAuth.HttpContext != null &&
                                 serviceAuth.HttpContext.User.Identity.IsAuthenticated;
            
            context.Menu.AddItem(new ApplicationMenuItem("MENU", "Crud display", "/Crud"));
            if (isAutenticated)
            {
                context.Menu.AddItem(new ApplicationMenuItem("MENU", "Usuarios", "/Users"));
            }
        }
    }
}