using System.Collections.Generic;
using Iconiz.Boilerplate.Caching.Dto;

namespace Iconiz.Boilerplate.Web.Areas.AppAreaName.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}