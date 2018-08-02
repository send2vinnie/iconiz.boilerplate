using Iconiz.Boilerplate.Configuration.Dto;

namespace Iconiz.Boilerplate.Web.Areas.AppAreaName.Models.UiCustomization
{
    public class UiCustomizationViewModel
    {
        public UiCustomizationSettingsEditDto Settings { get; set; }

        public bool HasUiCustomizationPagePermission { get; set; }
    }
}
