using System;
using System.Linq;
using Abp.Organizations;
using Iconiz.Boilerplate.Authorization.Roles;
using Iconiz.Boilerplate.MultiTenancy;

namespace Iconiz.Boilerplate.EntityHistory
{
    public static class EntityHistoryHelper
    {
        public static readonly Type[] TrackedTypes =
            HostSideTrackedTypes
                .Concat(TenantSideTrackedTypes)
                .GroupBy(type=>type.FullName)
                .Select(types=>types.First())
                .ToArray();

        public static readonly Type[] HostSideTrackedTypes =
        {
            typeof(OrganizationUnit), typeof(Role), typeof(Tenant)
        };

        public static readonly Type[] TenantSideTrackedTypes =
        {
            typeof(OrganizationUnit), typeof(Role)
        };
    }
}
