using Abp.Authorization;
using Iconiz.Boilerplate.Authorization.Roles;
using Iconiz.Boilerplate.Authorization.Users;

namespace Iconiz.Boilerplate.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
