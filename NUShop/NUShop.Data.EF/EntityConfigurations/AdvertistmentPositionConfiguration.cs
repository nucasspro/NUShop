using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class AdvertistmentPositionConfiguration : DbEntityConfiguration<AdvertistmentPosition>
    {
        public override void Configure(EntityTypeBuilder<AdvertistmentPosition> entity)
        {
            entity.ToTable("AdvertistmentPositions");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("varchar(255)");
            entity.Property(x => x.Name).IsRequired(false).HasColumnName("Name").HasColumnType("nvarchar(255)");

            entity.Property(x => x.PageId).IsRequired(false).HasColumnName("PageId").HasColumnType("varchar(255)");
            entity.HasOne(x => x.AdvertistmentPage).WithMany(y => y.AdvertistmentPositions).HasForeignKey(z => z.PageId);
        }
    }
}