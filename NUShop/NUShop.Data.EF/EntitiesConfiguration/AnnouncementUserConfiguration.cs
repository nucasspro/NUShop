using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class AnnouncementUserConfiguration : DbEntityConfiguration<AnnouncementUser>
    {
        public override void Configure(EntityTypeBuilder<AnnouncementUser> builder)
        {
            builder.ToTable("AnnouncementUsers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");

            builder.Property(x => x.AnnouncementId).IsRequired(true).HasColumnName("AnnouncementId").HasColumnType("varchar(255)");
            builder.HasOne(x => x.Announcement).WithMany(y => y.AnnouncementUsers).HasForeignKey(z => z.AnnouncementId);

            builder.Property(x => x.UserId).IsRequired(true).HasColumnName("UserId").HasColumnType("uniqueidentifier");
            builder.Property(x => x.HasRead).IsRequired(false).HasColumnName("HasRead").HasColumnType("bit");
        }
    }
}