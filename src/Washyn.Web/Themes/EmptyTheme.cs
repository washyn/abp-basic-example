using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.DependencyInjection;

namespace Washyn.Web.Themes
{
    [ThemeName(Name)]
    public class EmptyTheme : ITheme, ITransientDependency
    {
        public const string Name = "Empty";

        public virtual string GetLayout(string name, bool fallbackToDefault = true)
        {
            switch (name)
            {
                case StandardLayouts.Application:
                    return "~/Themes/Empty/Layouts/Application.cshtml";
                case StandardLayouts.Account:
                    return "~/Themes/Empty/Layouts/Account.cshtml";
                case StandardLayouts.Empty:
                    return "~/Themes/Empty/Layouts/Empty.cshtml";
                default:
                    return fallbackToDefault
                        ? "~/Themes/Empty/Layouts/Application.cshtml"
                        : null;
            }
        }
    }
}