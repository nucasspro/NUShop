using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using System;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class IdentityUserTokenConfiguration : DbEntityConfiguration<IdentityUserToken<Guid>>
    {
        public override void Configure(EntityTypeBuilder<IdentityUserToken<Guid>> entity)
        {
            entity.ToTable("AppUserTokens").HasKey(x => new { x.UserId });
        }
    }
}