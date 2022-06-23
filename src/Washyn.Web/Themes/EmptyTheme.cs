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
                    return "~/Themes/Basic/Layouts/Application.cshtml";
                case StandardLayouts.Account:
                    return "~/Themes/Basic/Layouts/Account.cshtml";
                case StandardLayouts.Empty:
                    return "~/Themes/Basic/Layouts/Empty.cshtml";
                default:
                    return fallbackToDefault
                        ? "~/Themes/Basic/Layouts/Application.cshtml"
                        : null;
            }
        }
    }
}