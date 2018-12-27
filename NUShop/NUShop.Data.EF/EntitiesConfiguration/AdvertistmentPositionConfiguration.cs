using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class AdvertistmentPositionConfiguration : DbEntityConfiguration<AdvertistmentPosition>
    {
        public override void Configure(EntityTypeBuilder<AdvertistmentPosition> builder)
        {
            builder.ToTable("AdvertistmentPositions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("varchar(255)");
            builder.Property(x => x.Name).IsRequired(false).HasColumnName("Name").HasColumnType("nvarchar(255)");

            builder.Property(x => x.PageId).IsRequired(false).HasColumnName("PageId").HasColumnType("nvarchar(255)");
            builder.HasOne(x => x.AdvertistmentPage).WithMany(y => y.AdvertistmentPositions).HasForeignKey(z => z.PageId);
        }
    }
}