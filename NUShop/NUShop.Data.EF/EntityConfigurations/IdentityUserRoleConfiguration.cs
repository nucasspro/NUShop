using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using System;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class IdentityUserRoleConfiguration : DbEntityConfiguration<IdentityUserRole<Guid>>
    {
        public override void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> entity)
        {
            entity.ToTable("AppUserRoles").HasKey(x => new { x.RoleId, x.UserId });
        }
    }
}