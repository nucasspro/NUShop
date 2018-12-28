using Microsoft.AspNetCore.Identity;
using System;

namespace NUShop.Data.Entities
{
    public class AppRoleClaim : IdentityRoleClaim<Guid>
    {
        public AppRoleClaim()
        {
        }

        public AppRole AppRole { get; set; }
    }
}