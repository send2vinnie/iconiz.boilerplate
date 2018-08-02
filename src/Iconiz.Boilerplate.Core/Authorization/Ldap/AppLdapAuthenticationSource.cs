using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using Iconiz.Boilerplate.Authorization.Users;
using Iconiz.Boilerplate.MultiTenancy;

namespace Iconiz.Boilerplate.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}