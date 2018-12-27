using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntityConfigurations
{
    public class FunctionConfiguration : DbEntityConfiguration<Function>

    {
        public override void Configure(EntityTypeBuilder<Function> entity)
        {
            entity.ToTable("Functions");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("nvarchar(255)");
            entity.Property(x => x.Name).IsRequired(true).HasColumnName("Name").HasColumnType("nvarchar(255)");
            entity.Property(x => x.URL).IsRequired(true).HasColumnName("URL").HasColumnType("nvarchar(255)");
            entity.Property(x => x.ParentId).IsRequired(false).HasColumnName("ParentId").HasColumnType("nvarchar(255)");
            entity.Property(x => x.IconCss).IsRequired(false).HasColumnName("IconCss").HasColumnType("varchar(MAX)");
            entity.Property(x => x.SortOrder).IsRequired(true).HasColumnName("SortOrder").HasColumnType("int");
            entity.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("int");
        }
    }
}