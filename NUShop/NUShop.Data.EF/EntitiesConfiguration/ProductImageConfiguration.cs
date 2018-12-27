using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class ProductImageConfiguration : DbEntityConfiguration<ProductImage>
    {
        public override void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImages");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");

            builder.Property(x => x.ProductId).IsRequired(true).HasColumnName("ProductId").HasColumnType("int");
            builder.HasOne(x => x.Product).WithMany(y => y.ProductImages).HasForeignKey(z => z.ProductId);

            builder.Property(x => x.Path).IsRequired(false).HasColumnName("Path").HasColumnType("varchar(255)");
            builder.Property(x => x.Caption).IsRequired(false).HasColumnName("Caption").HasColumnType("varchar(255)");
        }
    }
}