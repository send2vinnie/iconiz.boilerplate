using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using Abp.Runtime.Session;
using Abp.UI;
using Iconiz.Boilerplate.Authorization;
using Iconiz.Boilerplate.IconizFinance.Dto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Iconiz.Boilerplate.IconizFinance;
using Microsoft.AspNetCore.Http;

namespace Iconiz.Boilerplate.IconizFinance
{
    [AbpAuthorize(AppPermissions.Pages_IconizTopic)]
    public class IconizTopicAppService : AsyncCrudAppService<IconizTopic, IconizTopicEditDto>
    {
        public IconizTopicAppService(IRepository<IconizTopic> repository)
            : base(repository)
        { }
    }
}