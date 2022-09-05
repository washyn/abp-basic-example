using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using TimeZoneNames;
using Volo.Abp.AspNetCore.Mvc.UI.Alerts;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Washyn.Web.Pages
{
    public class TestPage : AbpPageModel
    {
        public IDictionary<string, string> TimeZones { get; set; }
        public List<string> TimeZoneIds { get; set; }
        public string Others { get; set; }
        public string WindowsFormat { get; set; }
        public void OnGet()
        {
            #region Alerts

            Alerts.Add(new AlertMessage(AlertType.Danger, "Lorem ipsum es el texto.", "Titulo"));
            // Alerts.Add(new AlertMessage(AlertType.Dark, "Lorem ipsum es el texto.", "Titulo"));
            // Alerts.Add(new AlertMessage(AlertType.Default, "Lorem ipsum es el texto.", "Titulo"));
            // Alerts.Add(new AlertMessage(AlertType.Info, "Lorem ipsum es el texto.", "Titulo"));
            // Alerts.Add(new AlertMessage(AlertType.Light, "Lorem ipsum es el texto.", "Titulo"));
            // Alerts.Add(new AlertMessage(AlertType.Primary, "Lorem ipsum es el texto.", "Titulo"));
            // Alerts.Add(new AlertMessage(AlertType.Secondary, "Lorem ipsum es el texto.", "Titulo"));
            // Alerts.Add(new AlertMessage(AlertType.Success, "Lorem ipsum es el texto.", "Titulo"));
            // Alerts.Add(new AlertMessage(AlertType.Warning, "Lorem ipsum es el texto.", "Titulo"));

            #endregion



            #region Example show time zones

            var temp = TZNames.GetTimeZonesForCountry("pe", "es-pe");
            var temp2 = TZNames.GetTimeZoneIdsForCountry("pe");
            
            TimeZones = temp;
            TimeZoneIds = temp2.ToList();

            // recive el formato de windows
            Others = TimeZoneConverter.TZConvert.WindowsToIana("Eastern Standard Time");
            // retorna la zona horaria de formato windows
            
            // IANA to windows
            Others = TimeZoneConverter.TZConvert.IanaToWindows("America/Lima");
            WindowsFormat = TimeZoneConverter.TZConvert.IanaToWindows("America/Lima");
            Others = TimeZoneConverter.TZConvert.WindowsToIana(Others);

            #endregion
        }
    }
}