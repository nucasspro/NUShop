using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class ProductQuantityConfiguration : DbEntityConfiguration<ProductQuantity>
    {
        public override void Configure(EntityTypeBuilder<ProductQuantity> builder)
        {
            builder.ToTable("ProductQuantities");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");

            builder.Property(x => x.ProductId).IsRequired(true).HasColumnName("ProductId").HasColumnType("int");
            builder.HasOne(x => x.Product).WithMany(y => y.ProductQuantities).HasForeignKey(z => z.ProductId);

            builder.Property(x => x.ProductId).IsRequired(true).HasColumnName("ProductId").HasColumnType("int");
            builder.HasOne(x => x.Product).WithMany(y => y.ProductQuantities).HasForeignKey(z => z.ProductId);

            builder.Property(x => x.SizeId).IsRequired(true).HasColumnName("SizeId").HasColumnType("int");
            builder.HasOne(x => x.Size).WithMany(y => y.ProductQuantities).HasForeignKey(z => z.SizeId);

            builder.Property(x => x.ColorId).IsRequired(true).HasColumnName("ColorId").HasColumnType("int");
            builder.HasOne(x => x.Size).WithMany(y => y.ProductQuantities).HasForeignKey(z => z.ColorId);

            builder.Property(x => x.Quantity).IsRequired(true).HasColumnName("Quantity").HasColumnType("int");
        }
    }
}