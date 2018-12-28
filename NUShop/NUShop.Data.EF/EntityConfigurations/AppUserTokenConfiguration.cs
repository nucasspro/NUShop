using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;
using System;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class AppUserTokenConfiguration : DbEntityConfiguration<AppUserToken>
    {
        public override void Configure(EntityTypeBuilder<AppUserToken> entity)
        {
            entity.ToTable("AppUserTokens");
            entity.HasKey(x => new { x.UserId, x.LoginProvider });
            entity.HasOne(x => x.AppUser).WithMany(y => y.AppUserTokens).HasForeignKey(z => z.UserId);
        }
    }
}