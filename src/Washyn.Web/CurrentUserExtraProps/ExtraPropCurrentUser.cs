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
        
        // TODO: replace abp settings gender, and use this.
        public override bool IsAuthenticated => Id.HasValue;
        
        public int? Id => FindUserIdentifier();

        private int? FindUserIdentifier()
        {
            var res = this.FindClaimValue(ClaimTypes.NameIdentifier);
            
            if (res == null || res.IsNullOrWhiteSpace())
            {
                return null;
            }
            if (int.TryParse(res, out int id))
            {
                return id;
            }

            return null;
        }
    }
}