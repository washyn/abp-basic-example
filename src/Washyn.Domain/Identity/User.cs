using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Washyn.Domain.Identity
{
    public class User : Entity<int>
    {
        public string UserName { get; }

        [CanBeNull]
        public string Email { get; }

        [CanBeNull]
        public string Name { get; }

        [CanBeNull]
        public string Surname { get; }

        public bool IsActive { get; }

        [CanBeNull]
        public string PhoneNumber { get; }

        /// <summary>
        /// Gets or sets a salted and hashed representation of the password for this user.
        /// </summary>
        [DisableAuditing]
        public string PasswordHash { get; protected internal set; }

        public string RolName { get; set; }

        protected User()
        {
        }

        public User(string userName, string passwordHash, string rolName)
        {
            UserName = Check.NotNullOrEmpty(userName, nameof(userName));
            PasswordHash = Check.NotNullOrEmpty(passwordHash, nameof(passwordHash));
            SetRole(rolName);
        }

        public void SetRole(string rolName)
        {
            Check.NotNullOrEmpty(rolName, nameof(rolName));
            
            if (rolName != RolConsts.Admin && rolName != RolConsts.User)
            {
                throw new ArgumentException($"Rol value only be set as {RolConsts.Admin} or {RolConsts.User}");
            }
            RolName = rolName;
        }
    }
}