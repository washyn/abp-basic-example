using JetBrains.Annotations;
using System;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;

namespace Washyn.Web.CurrentUserExtraProps
{
    public interface IExtraPropCurrentUser : ICurrentUser
    {
        new int? Id { get; }
    }
}