using Microsoft.AspNetCore.Identity;
using System;

namespace NUShop.Data.Entities
{
    public class AppUserToken : IdentityUserToken<Guid>
    {
        public AppUser AppUser { get; set; }
    }
}