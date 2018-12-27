using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class SystemConfigConfiguration : DbEntityConfiguration<SystemConfig>
    {
        public override void Configure(EntityTypeBuilder<SystemConfig> builder)
        {
            builder.ToTable("SystemConfigs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("varchar(255)");
            builder.Property(x => x.Name).IsRequired(false).HasColumnName("Name").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Value1).IsRequired(false).HasColumnName("Value1").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Value2).IsRequired(false).HasColumnName("Value2").HasColumnType("int");
            builder.Property(x => x.Value3).IsRequired(false).HasColumnName("Value3").HasColumnType("bit");
            builder.Property(x => x.Value5).IsRequired(false).HasColumnName("Value5").HasColumnType("decimal");
            builder.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("bit");
        }
    }
}