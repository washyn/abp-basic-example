﻿using System;

namespace Washyn.Web.Models
{
    [Serializable]
    public class CustomCurrentUserDto
    {
        public bool IsAuthenticated { get; set; }

        public int? Id { get; set; }

        public Guid? TenantId { get; set; }

        public Guid? ImpersonatorUserId { get; set; }

        public Guid? ImpersonatorTenantId { get; set; }

        public string ImpersonatorUserName { get; set; }

        public string ImpersonatorTenantName { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string Email { get; set; }

        public bool EmailVerified { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberVerified { get; set; }

        public string[] Roles { get; set; }
    }
}