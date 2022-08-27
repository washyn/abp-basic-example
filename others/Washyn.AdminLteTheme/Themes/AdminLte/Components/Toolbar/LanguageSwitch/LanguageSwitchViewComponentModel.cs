﻿using System.Collections.Generic;
using Volo.Abp.Localization;

namespace Washyn.AdminLteTheme.Themes.AdminLte.Components.Toolbar.LanguageSwitch
{
    public class LanguageSwitchViewComponentModel
    {
        public LanguageInfo CurrentLanguage { get; set; }

        public List<LanguageInfo> OtherLanguages { get; set; }
    }
}