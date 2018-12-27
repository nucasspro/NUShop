using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using System;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class IdentityUserLoginConfiguration : DbEntityConfiguration<IdentityUserLogin<Guid>>
    {
        public override void Configure(EntityTypeBuilder<IdentityUserLogin<Guid>> entity)
        {
            entity.ToTable("AppUserLogins").HasKey(x => x.UserId);
        }
    }
}