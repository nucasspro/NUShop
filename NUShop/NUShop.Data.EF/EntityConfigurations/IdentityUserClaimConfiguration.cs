using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using System;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class IdentityUserClaimConfiguration : DbEntityConfiguration<IdentityUserClaim<Guid>>

    {
        public override void Configure(EntityTypeBuilder<IdentityUserClaim<Guid>> entity)
        {
            entity.ToTable("AppUserClaims").HasKey(x => x.Id);
        }
    }
}