using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUShop.Data.EF.Extensions;
using NUShop.Data.Entities;

namespace NUShop.Data.EF.EntitiesConfiguration
{
    public class FeedbackConfiguration : DbEntityConfiguration<Feedback>
    {
        public override void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedbacks");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true).HasColumnName("Id").HasColumnType("int");
            builder.Property(x => x.Name).IsRequired(true).HasColumnName("Name").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Email).IsRequired(false).HasColumnName("Email").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Message).IsRequired(false).HasColumnName("Message").HasColumnType("nvarchar(500)");
            builder.Property(x => x.Status).IsRequired(true).HasColumnName("Status").HasColumnType("int");
            builder.Property(x => x.DateCreated).IsRequired(true).HasColumnName("DateCreated").HasColumnType("datetime");
            builder.Property(x => x.DateModified).IsRequired(true).HasColumnName("DateModified").HasColumnType("datetime");
        }
    }
}