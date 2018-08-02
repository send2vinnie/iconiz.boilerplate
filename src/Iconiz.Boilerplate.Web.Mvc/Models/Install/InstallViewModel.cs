using System.Collections.Generic;
using Abp.Localization;
using Iconiz.Boilerplate.Install.Dto;

namespace Iconiz.Boilerplate.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}
