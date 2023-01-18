using JetBrains.Annotations;
using System;
using System.Linq;
using System.Security.Claims;
using Volo.Abp;
using Volo.Abp.Security.Claims;

namespace Washyn.Web
{
    public static class CustomIdentityClaimsExtensions
    {
        public static int? FindUserIdentifier([NotNull] this ClaimsPrincipal principal)
        {
            Check.NotNull(principal, nameof(principal));

            var userIdOrNull = principal.Claims?.FirstOrDefault(c => c.Type == AbpClaimTypes.UserId);
            if (userIdOrNull == null || userIdOrNull.Value.IsNullOrWhiteSpace())
            {
                return null;
            }

            if (int.TryParse(userIdOrNull.Value, out int guid))
            {
                return guid;
            }

            return null;
        }
    }
}