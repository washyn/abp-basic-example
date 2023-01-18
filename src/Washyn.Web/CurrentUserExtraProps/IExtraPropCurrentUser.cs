using JetBrains.Annotations;
using System;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;

namespace Washyn.Web.CurrentUserExtraProps
{
    [Dependency(ReplaceServices = true)]
    public interface IExtraPropCurrentUser : ICurrentUser
    {
        int? UserId { get; }

        // TODO: implement this
        // new int? Id { get; }
    }
}