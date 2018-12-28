using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;
using System;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class AppRoleClaimConfiguration : DbEntityConfiguration<AppRoleClaim>
    {
        public override void Configure(EntityTypeBuilder<AppRoleClaim> entity)
        {
            entity.ToTable("AppRoleClaims");
            entity.HasKey(x => x.Id);
            entity.HasOne(x => x.AppRole).WithMany(y => y.AppRoleClaims).HasForeignKey(z => z.RoleId);
        }
    }
}