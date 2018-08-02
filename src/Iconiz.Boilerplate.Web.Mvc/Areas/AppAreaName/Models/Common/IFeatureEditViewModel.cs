using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Iconiz.Boilerplate.Editions.Dto;

namespace Iconiz.Boilerplate.Web.Areas.AppAreaName.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}