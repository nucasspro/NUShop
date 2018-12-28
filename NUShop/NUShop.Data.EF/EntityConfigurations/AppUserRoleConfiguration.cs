using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;
using System;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class AppUserRoleConfiguration : DbEntityConfiguration<AppUserRole>
    {
        public override void Configure(EntityTypeBuilder<AppUserRole> entity)
        {
            entity.ToTable("AppUserRoles");
            entity.HasKey(x => new { x.RoleId, x.UserId });

            entity.HasOne(x => x.AppRole).WithMany(y => y.AppUserRoles).HasForeignKey(z => z.RoleId);
            entity.HasOne(x => x.AppUser).WithMany(y => y.AppUserRoles).HasForeignKey(z => z.UserId );

        }
    }
}