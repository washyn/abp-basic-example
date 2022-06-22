using Volo.Abp.AspNetCore.Mvc.UI.Theming;

namespace Washyn.Web.Services
{
    public class ThemeManager : IThemeManager
    {
        public ITheme CurrentTheme { get; }

        public ThemeManager()
        {
            // Volo.Abp.AspNetCore.Mvc.UI.Theming.ThemeExtensions.GetApplicationLayout()
        }
        
        public override string ToString()
        {
            return string.Empty;
        }
    }
}