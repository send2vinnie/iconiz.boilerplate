using System.Collections.Generic;
using Iconiz.Boilerplate.Authorization.Users.Dto;

namespace Iconiz.Boilerplate.Web.Areas.AppAreaName.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}