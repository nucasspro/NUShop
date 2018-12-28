using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUShop.Data.Entities
{
    public  class AppUserLogin : IdentityUserLogin<Guid>
    {
        public AppUser AppUser { get; set; }
    }
}
