using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class ProductCategoryConfiguration : DbEntityConfiguration<ProductCategory>
    {
        public override void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");
            builder.Property(x => x.Name).IsRequired(false).HasColumnName("Name").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Description).IsRequired(false).HasColumnName("Description").HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.ParentId).IsRequired(false).HasColumnName("ParentId").HasColumnType("int");
            builder.Property(x => x.HomeOrder).IsRequired(false).HasColumnName("HomeOrder").HasColumnType("int");
            builder.Property(x => x.HomeFlag).IsRequired(false).HasColumnName("HomeFlag").HasColumnType("bit");
            builder.Property(x => x.Image).IsRequired(false).HasColumnName("Image").HasColumnType("varchar(255)");
            builder.Property(x => x.SortOrder).IsRequired(true).HasColumnName("SortOrder").HasColumnType("int");
            builder.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("int");
            builder.Property(x => x.SeoPageTitle).IsRequired(false).HasColumnName("SeoPageTitle").HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.SeoAlias).IsRequired(false).HasColumnName("SeoAlias").HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.SeoKeywords).IsRequired(false).HasColumnName("SeoKeywords").HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.SeoDescription).IsRequired(false).HasColumnName("SeoDescription").HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.DateCreated).IsRequired(false).HasColumnName("DateCreated").HasColumnType("datetime");
            builder.Property(x => x.DateModified).IsRequired(false).HasColumnName("DateModified").HasColumnType("datetime");
        }
    }
}