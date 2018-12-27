using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class BlogTagConfiguration : DbEntityConfiguration<BlogTag>
    {
        public override void Configure(EntityTypeBuilder<BlogTag> builder)
        {
            builder.ToTable("BlogTags");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");

            builder.Property(x => x.BlogId).IsRequired(true).HasColumnName("BlogId").HasColumnType("int");
            builder.HasOne(x => x.Blog).WithMany(y => y.BlogTags).HasForeignKey(z => z.BlogId);

            builder.Property(x => x.TagId).IsRequired(true).HasColumnName("TagId").HasColumnType("varchar(255)");
            builder.HasOne(x => x.Tag).WithMany(y => y.BlogTags).HasForeignKey(z => z.TagId);
        }
    }
}