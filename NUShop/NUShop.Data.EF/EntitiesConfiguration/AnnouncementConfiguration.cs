using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class AnnouncementConfiguration : DbEntityConfiguration<Announcement>
    {
        public override void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.ToTable("Announcements");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("varchar(255)");
            builder.Property(x => x.Title).IsRequired(true).HasColumnName("Title").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Content).IsRequired(false).HasColumnName("Content").HasColumnType("nvarchar(255)");

            builder.Property(x => x.UserId).IsRequired(true).HasColumnName("UserId").HasColumnType("uniqueidentifier");
            builder.HasOne(x => x.AppUser).WithMany(y => y.Announcements).HasForeignKey(z => z.UserId);

            builder.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("int");
            builder.Property(x => x.DateCreated).IsRequired(false).HasColumnName("DateCreated").HasColumnType("datetime");
            builder.Property(x => x.DateModified).IsRequired(false).HasColumnName("DateModified").HasColumnType("datetime");
        }
    }
}