using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using System;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class IdentityRoleClaimConfiguration : DbEntityConfiguration<IdentityRoleClaim<Guid>>
    {
        public override void Configure(EntityTypeBuilder<IdentityRoleClaim<Guid>> entity)
        {
            entity.ToTable("AppRoleClaims").HasKey(x => x.Id);
        }
    }
}