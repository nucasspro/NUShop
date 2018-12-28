using Microsoft.AspNetCore.Identity;
using NUShop.Data.Enums;
using NUShop.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace NUShop.Data.Entities
{
    public class AppUser : IdentityUser<Guid>, IDateTracking, ISwitchable
    {
        public AppUser()
        {
        }

        public AppUser(Guid id, string fullName, string userName,
            string email, string phoneNumber, string avatar)
        {
            Id = id;
            FullName = fullName;
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            Avatar = avatar;
            Status = Status.Active;
        }

        public string FullName { get; set; }
        public DateTime? BirthDay { set; get; }
        public decimal Balance { get; set; }
        public string Avatar { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<AppUserRole> AppUserRoles { get; set; }
        public virtual ICollection<AppUserClaim> AppUserClaims { get; set; }
        public virtual ICollection<AppUserLogin> AppUserLogins { get; set; }
        public virtual ICollection<AppUserToken> AppUserTokens { get; set; }
    }
}