using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class WholePriceConfiguration : DbEntityConfiguration<WholePrice>
    {
        public override void Configure(EntityTypeBuilder<WholePrice> builder)
        {
            builder.ToTable("WholePrices");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");

            builder.Property(x => x.ProductId).IsRequired(true).HasColumnName("ProductId").HasColumnType("int");
            builder.HasOne(x => x.Product).WithMany(y => y.WholePrices).HasForeignKey(z => z.ProductId);

            builder.Property(x => x.FromQuantity).IsRequired(true).HasColumnName("FromQuantity").HasColumnType("int");
            builder.Property(x => x.ToQuantity).IsRequired(true).HasColumnName("ToQuantity").HasColumnType("int");
            builder.Property(x => x.Price).IsRequired(true).HasColumnName("Price").HasColumnType("decimal");
        }
    }
}