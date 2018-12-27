using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class ProductConfiguration : DbEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");
            builder.Property(x => x.Name).IsRequired(true).HasColumnName("Name").HasColumnType("nvarchar(255)");

            builder.Property(x => x.CategoryId).IsRequired(true).HasColumnName("CategoryId").HasColumnType("int");
            builder.HasOne(x => x.ProductCategory).WithMany(y => y.Products).HasForeignKey(z => z.CategoryId);

            builder.Property(x => x.Image).IsRequired(false).HasColumnName("Image").HasColumnType("varchar(255)");
            builder.Property(x => x.Price).IsRequired(true).HasColumnName("Price").HasColumnType("decimal").HasDefaultValue(0);
            builder.Property(x => x.PromotionPrice).IsRequired(false).HasColumnName("PromotionPrice").HasColumnType("decimal");
            builder.Property(x => x.OriginalPrice).IsRequired(true).HasColumnName("OriginalPrice").HasColumnType("decimal");
            builder.Property(x => x.Description).IsRequired(false).HasColumnName("Description").HasColumnType("text");
            builder.Property(x => x.Content).IsRequired(false).HasColumnName("Content").HasColumnType("text");
            builder.Property(x => x.HomeFlag).IsRequired(false).HasColumnName("HomeFlag").HasColumnType("bit");
            builder.Property(x => x.HotFlag).IsRequired(false).HasColumnName("HotFlag").HasColumnType("bit");
            builder.Property(x => x.ViewCount).IsRequired(false).HasColumnName("ViewCount").HasColumnType("int");
            builder.Property(x => x.Tags).IsRequired(false).HasColumnName("Tags").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Unit).IsRequired(false).HasColumnName("Unit").HasColumnType("nvarchar(255)");

            builder.Property(x => x.SeoPageTitle).IsRequired(false).HasColumnName("SeoPageTitle").HasColumnType("nvarchar(255)");
            builder.Property(x => x.SeoAlias).IsRequired(false).HasColumnName("SeoAlias").HasColumnType("nvarchar(255)");
            builder.Property(x => x.SeoKeywords).IsRequired(false).HasColumnName("SeoKeywords").HasColumnType("nvarchar(255)");
            builder.Property(x => x.SeoDescription).IsRequired(false).HasColumnName("SeoDescription").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("int");
            builder.Property(x => x.DateCreated).IsRequired(false).HasColumnName("DateCreated").HasColumnType("");
            builder.Property(x => x.DateModified).IsRequired(false).HasColumnName("DateModified").HasColumnType("");

        }
    }
}