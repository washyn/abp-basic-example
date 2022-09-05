using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Alerts;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Washyn.Web.Pages
{
    public class TestPage : AbpPageModel
    {
        public void OnGet()
        {
            Alerts.Add(new AlertMessage(AlertType.Danger, "Lorem ipsum es el texto.", "Titulo"));
            Alerts.Add(new AlertMessage(AlertType.Dark, "Lorem ipsum es el texto.", "Titulo"));
            Alerts.Add(new AlertMessage(AlertType.Default, "Lorem ipsum es el texto.", "Titulo"));
            Alerts.Add(new AlertMessage(AlertType.Info, "Lorem ipsum es el texto.", "Titulo"));
            Alerts.Add(new AlertMessage(AlertType.Light, "Lorem ipsum es el texto.", "Titulo"));
            Alerts.Add(new AlertMessage(AlertType.Primary, "Lorem ipsum es el texto.", "Titulo"));
            Alerts.Add(new AlertMessage(AlertType.Secondary, "Lorem ipsum es el texto.", "Titulo"));
            Alerts.Add(new AlertMessage(AlertType.Success, "Lorem ipsum es el texto.", "Titulo"));
            Alerts.Add(new AlertMessage(AlertType.Warning, "Lorem ipsum es el texto.", "Titulo"));
        }
    }
}