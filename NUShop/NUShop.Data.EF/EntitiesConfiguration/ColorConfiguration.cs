using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class ColorConfiguration : DbEntityConfiguration<Color>
    {
        public override void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Colors");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");
            builder.Property(x => x.Name).IsRequired(false).HasColumnName("Name").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Code).IsRequired(false).HasColumnName("Code").HasColumnType("nvarchar(255)");
        }
    }
}