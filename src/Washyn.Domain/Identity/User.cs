using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Washyn.Domain.Identity
{
    public class User : Entity<int>
    {
        public string UserName { get; internal set;}

        [CanBeNull]
        public string Email { get; set;}

        [CanBeNull]
        public string Name { get; set;}

        [CanBeNull]
        public string Surname { get; set;}

        public bool IsActive { get;  set;}

        [CanBeNull]
        public string PhoneNumber { get; set;}

        /// <summary>
        /// Gets or sets a salted and hashed representation of the password for this user.
        /// </summary>
        [DisableAuditing]
        public string PasswordHash { get; internal set; }

        public string RolName { get; internal set; }

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
        
        public void SetPassword(string passwordHash)
        {
            PasswordHash = Check.NotNullOrEmpty(passwordHash, nameof(passwordHash));
        }
    }
}