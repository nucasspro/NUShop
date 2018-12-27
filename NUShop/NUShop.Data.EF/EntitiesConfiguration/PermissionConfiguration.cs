using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class PermissionConfiguration : DbEntityConfiguration<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");
            builder.Property(x => x.RoleId).IsRequired(true).HasColumnName("RoleId").HasColumnType("uniqueidentifier");
            builder.HasOne(x => x.AppRole).WithMany(y => y.Permissions).HasForeignKey(z => z.RoleId);

            builder.Property(x => x.FunctionId).IsRequired(true).HasColumnName("FunctionId").HasColumnType("nvarchar(255)");
            builder.HasOne(x => x.Function).WithMany(y => y.Permissions).HasForeignKey(z => z.FunctionId);

            builder.Property(x => x.CanCreate).IsRequired(true).HasColumnName("CanCreate").HasColumnType("bit");
            builder.Property(x => x.CanRead).IsRequired(true).HasColumnName("CanRead").HasColumnType("bit"); ;
            builder.Property(x => x.CanUpdate).IsRequired(true).HasColumnName("CanUpdate").HasColumnType("bit"); ;
            builder.Property(x => x.CanDelete).IsRequired(true).HasColumnName("CanDelete").HasColumnType("bit"); ;
        }
    }
}