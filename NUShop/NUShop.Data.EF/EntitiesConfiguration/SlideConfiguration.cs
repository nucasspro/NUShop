using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class SlideConfiguration : DbEntityConfiguration<Slide>
    {
        public override void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("Slides");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true).HasColumnName("Name").HasColumnType("int");
            builder.Property(x => x.Name).IsRequired(true).HasColumnName("Name").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Description).IsRequired(false).HasColumnName("Description").HasColumnType("text");
            builder.Property(x => x.Image).IsRequired(true).HasColumnName("Image").HasColumnType("varchar(255)");
            builder.Property(x => x.Url).IsRequired(true).HasColumnName("Url").HasColumnType("varchar(255)");
            builder.Property(x => x.DisplayOrder).IsRequired(false).HasColumnName("DisplayOrder").HasColumnType("int");
            builder.Property(x => x.Status).IsRequired(false).HasColumnName("Status").HasColumnType("bit");
            builder.Property(x => x.Content).IsRequired(false).HasColumnName("Content").HasColumnType("text");
            builder.Property(x => x.GroupAlias).IsRequired(true).HasColumnName("GroupAlias").HasColumnType("nvarchar(25)");
        }
    }
}