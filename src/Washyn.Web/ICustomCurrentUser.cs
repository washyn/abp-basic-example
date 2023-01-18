﻿using JetBrains.Annotations;
using System;
using System.Security.Claims;

namespace Washyn.Web
{
    public interface ICustomCurrentUser
    {
        bool IsAuthenticated { get; }

        [CanBeNull]
        int? Id { get; }

        [CanBeNull]
        string UserName { get; }

        [CanBeNull]
        string Name { get; }

        [CanBeNull]
        string SurName { get; }

        [CanBeNull]
        string PhoneNumber { get; }

        bool PhoneNumberVerified { get; }

        [CanBeNull]
        string Email { get; }

        bool EmailVerified { get; }

        Guid? TenantId { get; }

        [NotNull]
        string[] Roles { get; }

        [CanBeNull]
        Claim FindClaim(string claimType);

        [NotNull]
        Claim[] FindClaims(string claimType);

        [NotNull]
        Claim[] GetAllClaims();

        bool IsInRole(string roleName);
    }
}