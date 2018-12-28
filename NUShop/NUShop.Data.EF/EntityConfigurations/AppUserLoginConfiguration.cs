using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class AppUserLoginConfiguration : DbEntityConfiguration<AppUserLogin>
    {
        public override void Configure(EntityTypeBuilder<AppUserLogin> entity)
        {
            entity.ToTable("AppUserLogins");
            entity.HasKey(x => x.UserId);
            entity.HasOne(x => x.AppUser).WithMany(y => y.AppUserLogins).HasForeignKey(z => z.UserId);
        }
    }
}