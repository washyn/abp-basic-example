using JetBrains.Annotations;
using System;
using System.Diagnostics;
using Volo.Abp.Security.Claims;
using Volo.Abp.Users;

namespace Washyn.Web
{
    public static class CustomCurrentUserExtensions
    {
        [CanBeNull]
        public static string FindClaimValue(this ICustomCurrentUser currentUser, string claimType)
        {
            return currentUser.FindClaim(claimType)?.Value;
        }

        public static T FindClaimValue<T>(this ICustomCurrentUser currentUser, string claimType)
            where T : struct
        {
            var value = currentUser.FindClaimValue(claimType);
            if (value == null)
            {
                return default;
            }

            return value.To<T>();
        }

        public static int GetId(this ICustomCurrentUser currentUser)
        {
            Debug.Assert(currentUser.Id != null, "currentUser.Id != null");

            return currentUser.Id.Value;
        }

        public static Guid? FindImpersonatorTenantId([NotNull] this ICustomCurrentUser currentUser)
        {
            var impersonatorTenantId = currentUser.FindClaimValue(AbpClaimTypes.ImpersonatorTenantId);
            if (impersonatorTenantId.IsNullOrWhiteSpace())
            {
                return null;
            }
            if (Guid.TryParse(impersonatorTenantId, out var guid))
            {
                return guid;
            }

            return null;
        }

        public static Guid? FindImpersonatorUserId([NotNull] this ICustomCurrentUser currentUser)
        {
            var impersonatorUserId = currentUser.FindClaimValue(AbpClaimTypes.ImpersonatorUserId);
            if (impersonatorUserId.IsNullOrWhiteSpace())
            {
                return null;
            }
            if (Guid.TryParse(impersonatorUserId, out var guid))
            {
                return guid;
            }

            return null;
        }

        // public static string FindImpersonatorTenantName([NotNull] this ICustomCurrentUser currentUser)
        // {
        //     return currentUser.FindClaimValue(AbpClaimTypes.ImpersonatorTenantName);
        // }
        //
        // public static string FindImpersonatorUserName([NotNull] this ICustomCurrentUser currentUser)
        // {
        //     return currentUser.FindClaimValue(AbpClaimTypes.ImpersonatorUserName);
        // }
    }
}