using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Alerts;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Washyn.Internet.Pages
{
    public class Example : AbpPageModel
    {
        public void OnGet()
        {
            // Alerts.Add(new AlertMessage(AlertType.Default, "Texto de la alerta.", "Titulo", false));
            // Alerts.Add(new AlertMessage(AlertType.Primary, "Texto de la alerta.", "Titulo", false));
            // Alerts.Add(new AlertMessage(AlertType.Secondary, "Texto de la alerta.", "Titulo", false));
            // Alerts.Add(new AlertMessage(AlertType.Success, "Texto de la alerta.", "Titulo", false));
            // Alerts.Add(new AlertMessage(AlertType.Danger, "Texto de la alerta.", "Titulo", false));
            Alerts.Add(new AlertMessage(AlertType.Warning, "Texto de la alerta.", "Titulo", false));
            Alerts.Add(new AlertMessage(AlertType.Info, "Texto de la alerta.", "Titulo", true));
            Alerts.Add(new AlertMessage(AlertType.Light, "Texto de la alerta.", "Titulo", true));
            Alerts.Add(new AlertMessage(AlertType.Dark, "Texto de la alerta.", "Titulo", true));
        }
    }
}