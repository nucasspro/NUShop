using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class AppUserClaimConfiguration : DbEntityConfiguration<AppUserClaim>

    {
        public override void Configure(EntityTypeBuilder<AppUserClaim> entity)
        {
            entity.ToTable("AppUserClaims");
            entity.HasKey(x => x.Id);
            entity.HasOne(x => x.AppUser).WithMany(y => y.AppUserClaims).HasForeignKey(z => z.UserId);
        }
    }
}