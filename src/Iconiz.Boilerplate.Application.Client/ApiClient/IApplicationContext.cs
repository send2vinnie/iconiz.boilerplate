﻿using Abp.Localization;
using Abp.Web.Models.AbpUserConfiguration;
using JetBrains.Annotations;
using Iconiz.Boilerplate.Sessions.Dto;

namespace Iconiz.Boilerplate.ApiClient
{
    public interface IApplicationContext
    {
        [CanBeNull]
        TenantInformation CurrentTenant { get; }

        AbpUserConfigurationDto Configuration { get; set; }

        GetCurrentLoginInformationsOutput LoginInfo { get; set; }

        void SetAsHost();

        void SetAsTenant(string tenancyName, int tenantId);

        LanguageInfo CurrentLanguage { get; set; }
    }
}