using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Iconiz.Boilerplate.Configuration.Host.Dto;
using Iconiz.Boilerplate.Editions.Dto;

namespace Iconiz.Boilerplate.Web.Areas.AppAreaName.Models.HostSettings
{
    public class HostSettingsViewModel
    {
        public HostSettingsEditDto Settings { get; set; }

        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }

        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}