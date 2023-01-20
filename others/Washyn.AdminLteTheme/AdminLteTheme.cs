using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.DependencyInjection;

namespace Washyn.AdminLteTheme
{
    [ThemeName(Name)]
    public class AdminLteTheme : ITheme, ITransientDependency
    {
        public const string Name = "AdminLte";

        public string GetLayout(string name, bool fallbackToDefault = true)
        {
            // AdminLteEmptyLayout
            switch (name)
            {
                case StandardLayouts.Application:
                    return "~/Themes/AdminLte/Layouts/Application.cshtml";
                case StandardLayouts.Account:
                    return "~/Themes/AdminLte/Layouts/Account.cshtml";
                case StandardLayouts.Empty:
                    return "~/Themes/AdminLte/Layouts/Empty.cshtml";
                case StandardLayouts.Public:
                    return "~/Themes/AdminLte/Layouts/Empty.cshtml";
                case "AdminLteEmptyLayout":
                    return "~/Themes/AdminLte/Layouts/AdminLteEmptyLayout.cshtml";
                
                default:
                    return fallbackToDefault ? "~/Themes/AdminLte/Layouts/Application.cshtml" : null;
            }
        }
    }
}