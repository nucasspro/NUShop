using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class SlideConfiguration : DbEntityConfiguration<Slide>
    {
        public override void Configure(EntityTypeBuilder<Slide> entity)
        {
            entity.ToTable("Slides");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");
            entity.Property(x => x.Name).IsRequired(true).HasColumnName("Name").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Description).IsRequired(false).HasColumnName("Description").HasColumnType("text");
            entity.Property(x => x.Image).IsRequired(true).HasColumnName("Image").HasColumnType("varchar(255)");
            entity.Property(x => x.Url).IsRequired(true).HasColumnName("Url").HasColumnType("varchar(255)");
            entity.Property(x => x.DisplayOrder).IsRequired(false).HasColumnName("DisplayOrder").HasColumnType("int");
            entity.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("bit");
            entity.Property(x => x.Content).IsRequired(false).HasColumnName("Content").HasColumnType("text");
            entity.Property(x => x.GroupAlias).IsRequired(true).HasColumnName("GroupAlias").HasColumnType("nvarchar(25)");
        }
    }
}