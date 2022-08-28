using System.Threading.Tasks;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Washyn.Internet.Localization;

namespace Washyn.Internet.Menus
{
    public class InternetMenuContributor : IMenuContributor
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
            var administration = context.Menu.GetAdministration();
            var l = context.GetLocalizer<InternetResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    InternetMenus.Home,
                    l["Menu:Home"],
                    "~/",
                    icon: "fas fa-home",
                    order: 0
                )
            );
            
            if (InternetModule.IsMultiTenant)
            {
                administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
            }
            else
            {
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
            administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
            
            // if (await context.IsGrantedAsync(InternetPermissions.Client.Default))
            // {
            //     context.Menu.AddItem(
            //         // new ApplicationMenuItem(InternetMenus.Client, l["Menu:Client"], "/Internet/Client")
            //         new ApplicationMenuItem(InternetMenus.Client, "Clientes", "/Administracion/Client")
            //     );
            // }
            
            // if (await context.IsGrantedAsync(InternetPermissions.Comprobante.Default))
            // {
            //     context.Menu.AddItem(
            //         new ApplicationMenuItem(InternetMenus.Comprobante, "Comprobantes")
            //             .AddItem(new ApplicationMenuItem("GenerarComproabante", "Generar", "/Administracion/Comprobante/Generar"))
            //             .AddItem(new ApplicationMenuItem("ListarPagos", "Ver pagos", "/Administracion/Comprobante/"))
            //     );
            // }
            
            // if (await context.IsGrantedAsync(InternetPermissions.Item.Default))
            // {
            //     context.Menu.AddItem(
            //         new ApplicationMenuItem(InternetMenus.Item, l["Menu:Item"], "/Internet/Item")
            //     );
            // }
        }
    }
}
