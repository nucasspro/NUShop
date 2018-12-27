using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class AdvertistmentConfiguration : DbEntityConfiguration<Advertistment>
    {
        public override void Configure(EntityTypeBuilder<Advertistment> builder)
        {
            builder.ToTable("Advertistments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");
            builder.Property(x => x.Name).IsRequired(false).HasColumnName("Name").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Description).IsRequired(false).HasColumnName("Description").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Image).IsRequired(false).HasColumnName("Image").HasColumnType("varchar(255)");
            builder.Property(x => x.Url).IsRequired(false).HasColumnName("URL").HasColumnType("varchar(255)");

            builder.Property(x => x.PositionId).IsRequired(false).HasColumnName("PositionId").HasColumnType("varchar(50)");
            builder.HasOne(x => x.AdvertistmentPosition).WithMany(y => y.Advertistments).HasForeignKey(z => z.PositionId);

            builder.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("int");
            builder.Property(x => x.SortOrder).IsRequired(true).HasColumnName("SortOrder").HasColumnType("int");
            builder.Property(x => x.DateCreated).IsRequired(false).HasColumnName("DateCreated").HasColumnType("datetime");
            builder.Property(x => x.DateModified).IsRequired(false).HasColumnName("DateModified").HasColumnType("datetime");
        }
    }
}