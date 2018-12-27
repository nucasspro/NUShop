using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class BillDetailConfiguration : DbEntityConfiguration<BillDetail>
    {
        public override void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.ToTable("BillDetails");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");

            builder.Property(x => x.BillId).IsRequired(true).HasColumnName("BillId").HasColumnType("int");
            builder.HasOne(x => x.Bill).WithMany(y => y.BillDetails).HasForeignKey(z => z.BillId);

            builder.Property(x => x.ProductId).IsRequired(true).HasColumnName("ProductId").HasColumnType("int");
            builder.HasOne(x => x.Product).WithMany(y => y.BillDetails).HasForeignKey(z => z.ProductId);

            builder.Property(x => x.Quantity).IsRequired(true).HasColumnName("Quantity").HasColumnType("int");
            builder.Property(x => x.Price).IsRequired(true).HasColumnName("Price").HasColumnType("decimal");

            builder.Property(x => x.ColorId).IsRequired(true).HasColumnName("ColorId").HasColumnType("int");
            builder.HasOne(x => x.Color).WithMany(y => y.BillDetails).HasForeignKey(z => z.ColorId);

            builder.Property(x => x.SizeId).IsRequired(true).HasColumnName("SizeId").HasColumnType("int");
            builder.HasOne(x => x.Size).WithMany(y => y.BillDetails).HasForeignKey(z => z.SizeId);
        }
    }
}