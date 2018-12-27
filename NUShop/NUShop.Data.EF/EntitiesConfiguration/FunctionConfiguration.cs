using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class FunctionConfiguration : DbEntityConfiguration<Function>

    {
        public override void Configure(EntityTypeBuilder<Function> builder)
        {
            builder.ToTable("Functions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Name).IsRequired(true).HasColumnName("Name").HasColumnType("nvarchar(255)");
            builder.Property(x => x.URL).IsRequired(true).HasColumnName("URL").HasColumnType("nvarchar(255)");
            builder.Property(x => x.ParentId).IsRequired(false).HasColumnName("ParentId").HasColumnType("nvarchar(255)");
            builder.Property(x => x.IconCss).IsRequired(false).HasColumnName("IconCss").HasColumnType("varchar(MAX)");
            builder.Property(x => x.SortOrder).IsRequired(true).HasColumnName("SortOrder").HasColumnType("int");
            builder.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("int");
        }
    }
}