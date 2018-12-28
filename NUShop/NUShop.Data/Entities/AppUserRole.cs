using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUShop.Data.Entities
{
    public class AppUserRole : IdentityUserRole<Guid>
    {
        public AppRole AppRole { get; set; }
        public AppUser AppUser { get; set; }
    }
}