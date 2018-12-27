using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class ProductTagConfiguration : DbEntityConfiguration<ProductTag>
    {
        public override void Configure(EntityTypeBuilder<ProductTag> builder)
        {
            builder.ToTable("ProductTags");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");

            builder.Property(x => x.ProductId).IsRequired(true).HasColumnName("ProductId").HasColumnType("int");
            builder.HasOne(x => x.Product).WithMany(y => y.ProductTags).HasForeignKey(z => z.ProductId);

            builder.Property(x => x.TagId).IsRequired(true).HasColumnName("TagId").HasColumnType("varchar(255)");
            builder.HasOne(x => x.Tag).WithMany(y => y.ProductTags).HasForeignKey(z => z.TagId);
        }
    }
}