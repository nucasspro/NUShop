using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class BlogConfiguration : DbEntityConfiguration<Blog>
    {
        public override void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blogs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");
            builder.Property(x => x.Name).IsRequired(true).HasColumnName("Name").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Image).IsRequired(false).HasColumnName("Image").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Description).IsRequired(false).HasColumnName("Description").HasColumnType("text");
            builder.Property(x => x.Content).IsRequired(false).HasColumnName("Content").HasColumnType("text");
            builder.Property(x => x.HomeFlag).IsRequired(false).HasColumnName("HomeFlag").HasColumnType("bit");
            builder.Property(x => x.HotFlag).IsRequired(false).HasColumnName("HotFlag").HasColumnType("bit");
            builder.Property(x => x.ViewCount).IsRequired(false).HasColumnName("ViewCount").HasColumnType("int");
            builder.Property(x => x.Tags).IsRequired(false).HasColumnName("Tags").HasColumnType("nvarchar(255)");
            builder.Property(x => x.SeoPageTitle).IsRequired(false).HasColumnName("SeoPageTitle").HasColumnType("nvarchar(255)");
            builder.Property(x => x.SeoAlias).IsRequired(false).HasColumnName("SeoAlias").HasColumnType("nvarchar(255)");
            builder.Property(x => x.SeoKeywords).IsRequired(false).HasColumnName("SeoKeywords").HasColumnType("nvarchar(255)");
            builder.Property(x => x.SeoDescription).IsRequired(false).HasColumnName("SeoDescription").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("int");
            builder.Property(x => x.DateCreated).IsRequired(true).HasColumnName("DateCreated").HasColumnType("datetime");
            builder.Property(x => x.DateModified).IsRequired(true).HasColumnName("DateModified").HasColumnType("datetime");
        }
    }
}