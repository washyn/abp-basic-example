using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.Localization;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.Localization;
using Volo.Abp.Users;

namespace Washyn.AdminLteTheme.Toolbars
{
    public class AdminLteThemeMainTopToolbarContributor : IToolbarContributor
    {
        public async Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
        {
            if (context.Toolbar.Name != StandardToolbars.Main)
            {
                return;
            }

            if (!(context.Theme is AdminLteTheme))
            {
                return;
            }

            var languageProvider = context.ServiceProvider.GetService<ILanguageProvider>();

            //TODO: This duplicates GetLanguages() usage. Can we eleminate this?
            var languages = await languageProvider.GetLanguagesAsync();
            if (languages.Count > 1)
            {
                context.Toolbar.Items.Add(new ToolbarItem(typeof(Washyn.AdminLteTheme.Themes.AdminLte.Components.Toolbar.LanguageSwitch.LanguageSwitchViewComponent)));
            }

            if (context.ServiceProvider.GetRequiredService<ICurrentUser>().IsAuthenticated)
            {
                context.Toolbar.Items.Add(new ToolbarItem(typeof(Washyn.AdminLteTheme.Themes.AdminLte.Components.Toolbar.UserMenu.UserMenuViewComponent)));
            }
        }
    }
}