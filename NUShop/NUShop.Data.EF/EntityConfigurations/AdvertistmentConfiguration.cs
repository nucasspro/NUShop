using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class AdvertistmentConfiguration : DbEntityConfiguration<Advertistment>
    {
        public override void Configure(EntityTypeBuilder<Advertistment> entity)
        {
            entity.ToTable("Advertistments");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");
            entity.Property(x => x.Name).IsRequired(false).HasColumnName("Name").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Description).IsRequired(false).HasColumnName("Description").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Image).IsRequired(false).HasColumnName("Image").HasColumnType("varchar(255)");
            entity.Property(x => x.Url).IsRequired(false).HasColumnName("URL").HasColumnType("varchar(255)");

            entity.Property(x => x.PositionId).IsRequired(false).HasColumnName("PositionId").HasColumnType("varchar(255)");
            entity.HasOne(x => x.AdvertistmentPosition).WithMany(y => y.Advertistments).HasForeignKey(z => z.PositionId);

            entity.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("int");
            entity.Property(x => x.SortOrder).IsRequired(true).HasColumnName("SortOrder").HasColumnType("int");
            entity.Property(x => x.DateCreated).IsRequired(true).HasColumnName("DateCreated").HasColumnType("varchar(255)");
            entity.Property(x => x.DateModified).IsRequired(true).HasColumnName("DateModified").HasColumnType("varchar(255)");
        }
    }
}