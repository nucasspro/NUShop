using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class AppUserConfiguration : DbEntityConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).IsRequired(false).HasColumnName("FullName").HasColumnType("nvarchar(255)");
            builder.Property(x => x.BirthDay).IsRequired(false).HasColumnName("BirthDay").HasColumnType("datetime");
            builder.Property(x => x.Balance).IsRequired(true).HasColumnName("Balance").HasColumnType("decimal");
            builder.Property(x => x.Avatar).IsRequired(false).HasColumnName("Avatar").HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.DateCreated).IsRequired(false).HasColumnName("DateCreated").HasColumnType("datetime");
            builder.Property(x => x.DateModified).IsRequired(false).HasColumnName("DateModified").HasColumnType("datetime");
            builder.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("int");
        }
    }
}