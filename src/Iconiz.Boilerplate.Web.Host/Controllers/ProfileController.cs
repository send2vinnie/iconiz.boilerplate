﻿using Abp.AspNetCore.Mvc.Authorization;

namespace Iconiz.Boilerplate.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ProfileController : ProfileControllerBase
    {
        public ProfileController(IAppFolders appFolders)
            : base(appFolders)
        {
        }
    }
}