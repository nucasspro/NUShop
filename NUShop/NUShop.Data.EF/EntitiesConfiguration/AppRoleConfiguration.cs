using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class AppRoleConfiguration : DbEntityConfiguration<AppRole>

    {
        public override void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("AppRoles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("uniqueidentifier");
            builder.Property(x => x.Name).IsRequired(false).HasColumnName("Name").HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.ConcurrencyStamp).IsRequired(false).HasColumnName("ConcurrencyStamp").HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.Description).IsRequired(false).HasColumnName("Description").HasColumnType("nvarchar(255)");
            builder.Property(x => x.NormalizedName).IsRequired(false).HasColumnName("NormalizedName").HasColumnType("nvarchar(MAX)");
        }
    }
}