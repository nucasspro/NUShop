using Microsoft.AspNetCore.Identity;
using System;

namespace NUShop.Data.Entities
{
    public class AppUserClaim : IdentityUserClaim<Guid>
    {
        public AppUser AppUser { get; set; }
    }
}