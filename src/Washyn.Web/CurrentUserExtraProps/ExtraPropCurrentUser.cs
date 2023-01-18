using System.Security.Claims;
using Volo.Abp.Security.Claims;
using Volo.Abp.Users;
using JetBrains.Annotations;
using System;
using System.Linq;
using System.Security.Claims;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;

namespace Washyn.Web.CurrentUserExtraProps
{
    [Dependency(ReplaceServices = true)]
    public class ExtraPropCurrentUser : CurrentUser, IExtraPropCurrentUser
    {
        public ExtraPropCurrentUser(ICurrentPrincipalAccessor principalAccessor) : base(principalAccessor)
        {
        }

        public virtual bool IsAuthenticated => UserId.HasValue;
        
        public int? FindUserIdentifier()
        {
            var res = this.FindClaimValue<int>(ClaimTypes.NameIdentifier);
            if (res == default)
            {
                return null;
            }
            return res;
        }
        
        public int? UserId => FindUserIdentifier();
    }
}